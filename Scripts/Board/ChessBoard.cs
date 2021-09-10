using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChessBoard : MonoBehaviour, IGameBoard
{
    public void AddUnit(Unit unit)
    {
        _units.Add(unit);
    }

    public Cell GetCell(Vector2Int position)
    {
        return _cells.Where(cell => cell.GetPosition() == position).FirstOrDefault();
    }
    
    public IEnumerable<Unit> GetUnit(Unit.Type type)
    {
        return _units.Where(u => u.UnitType == type);
    }

    public void Move(Unit unit, Cell cell)
    {
        Unit unitToKill = cell.IsOccupied() ? cell.GetUnit() : null;
        ICommand newMove = new UnitMoveCommand(unit, cell.GetPosition(), unitToKill);
        newMove.Execute();
        _commandHistory.Push(newMove);
    }

    public void UndoMove()
    {
        if (_commandHistory.Any())
        {
            UnitUI.HidePossibleMoves();
            ICommand lastMove = _commandHistory.Pop();
            lastMove.Undo();

            WhoseMove = WhoseMove == Unit.Team.White ? Unit.Team.Black : Unit.Team.White;
        }
    }

    public static Unit.Team WhoseMove
    {
        get { return _whoseMove; }
        set
        {
            _whoseMove = value;
            OnTeamTurnChanged?.Invoke();
        }
    }

    public bool IsMoveAvailable(Vector2Int move, Unit unit)
    {
        if (move.x >= _size || move.y >= _size
            || move.x < 0 || move.y < 0)
            return false;
        else if (GetCell(move).IsOccupied()
            && (GetCell(move).GetUnit().UnitTeam == unit.UnitTeam))
            return false;
        else if (unit.UnitType == Unit.Type.King)
            return IsMoveSafe(move, unit);
        else
            return true;
    }

    bool IsMoveSafe(Vector2Int move, Unit unit)
    {
        if (!_enemyMoves.Any())
        {
            CalculateDangerousMoves(move, unit);
        }

        if (_enemyMoves.Contains(move))
            return false;
        else 
            return true;
    }

    private void CalculateDangerousMoves(Vector2Int move, Unit unit)
    {
        Cell potentialCell = GetCell(move);
        Unit tempUnit = potentialCell.GetUnit();
        potentialCell.PlaceUnit(unit);

        CalculateEnemyMoves();

        if (tempUnit == null)
            potentialCell.ForgiveUnit();
        else
            potentialCell.PlaceUnit(tempUnit);
    }

    void CalculateEnemyMoves()
    {
        Unit.Team enemyTeam = WhoseMove == Unit.Team.Black ? Unit.Team.White : Unit.Team.Black;
        IEnumerable<Unit> enemyUnits = _units.Where(u => u.UnitTeam == enemyTeam && u.UnitType != Unit.Type.King);
        
        foreach (Unit enemyUnit in enemyUnits)
        {
            _enemyMoves.AddRange(enemyUnit.UI.GetPossibleMoves(enemyUnit, true));
        }
    }

    void ResetEnemyMoves()
    {
        if (_enemyMoves.Any()) _enemyMoves.Clear();
    }

    void Start()
    {
        OnTeamTurnChanged += ResetEnemyMoves;
    }



    static public Action OnTeamTurnChanged;
    static Unit.Team _whoseMove = Unit.Team.White;
    [SerializeField] List<Cell> _cells = new List<Cell>();
    [SerializeField] ICollection<Unit> _units = new List<Unit>();
    List<Vector2Int> _enemyMoves = new List<Vector2Int>(); // king moves not included
    Stack<ICommand> _commandHistory = new Stack<ICommand>();
    int _size = 8;
}
