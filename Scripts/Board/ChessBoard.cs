using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChessBoard : MonoBehaviour, IGameBoard
{
    public Cell GetCell(Vector2Int position)
    {
        return _cells.Where(cell => cell.GetPosition() == position).FirstOrDefault();
    }

    public bool IsMoveAvailable(Vector2Int move, Unit unit)
    {
        if (move.x >= _size || move.y >= _size
            || move.x < 0 || move.y < 0)
            return false;
        else if (GetCell(move).IsOccupied()
            && (GetCell(move).GetUnit().UnitTeam == unit.UnitTeam))
            return false;
        else
            return true;
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




    static public Action OnTeamTurnChanged;
    static Unit.Team _whoseMove = Unit.Team.White;
    [SerializeField] List<Cell> _cells = new List<Cell>();
    Stack<ICommand> _commandHistory = new Stack<ICommand>();
    int _size = 8;
}
