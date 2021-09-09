using System.Collections.Generic;
using UnityEngine;

public class UnitUI : MonoBehaviour
{
    public void ChangeType(Unit.Type type)
    {
        switch (type)
        {
            case Unit.Type.Pawn:
                _possibleMovesCalculator = new PawnPossibleMovesCalculator(_gameBoard);
                break;
            case Unit.Type.Root:
                _possibleMovesCalculator = new RootPossibleMovesCalculator(_gameBoard);
                break;
        }
    }

    public static void HidePossibleMoves()
    {
        foreach (Cell cell in _shownMoves)
            cell.Deactivate();
    }

    void ShowPossibeMoves(Unit unit)
    {
        HidePossibleMoves();

        List<Vector2Int> movesCoord = _possibleMovesCalculator.Calculate(unit);

        foreach (Vector2Int coord in movesCoord)
        {
            Cell cellToMove = _gameBoard.GetCell(coord);
            cellToMove.Activate(unit);
            _shownMoves.Add(cellToMove);
        }
    }

    void Awake()
    {
        _unit = GetComponent<Unit>();

        if (_gameBoard == null)
            _gameBoard = FindObjectOfType<ChessBoard>();
    }

    void OnMouseDown()
    {
        if (ChessBoard.WhoseMove == _unit.UnitTeam)
            ShowPossibeMoves(_unit);
    }



    IPossibleMovesCalculator _possibleMovesCalculator;
    static List<Cell> _shownMoves = new List<Cell>();
    static IGameBoard _gameBoard;
    Unit _unit;
}
