using System.Collections.Generic;
using UnityEngine;

public class UnitUI : MonoBehaviour
{
    public static void HidePossibleMoves()
    {
        foreach (Cell cell in _shownMoves)
            cell.Deactivate();
    }

    static void ShowPossibeMoves(Unit unit)
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

    void Start()
    {
        _unit = GetComponent<Unit>();

        if (_gameBoard == null)
            _gameBoard = FindObjectOfType<ChessBoard>();

        if(_possibleMovesCalculator == null)
            _possibleMovesCalculator = new PawnPossibleMovesCalculator(_gameBoard);
    }

    void OnMouseDown()
    {
        ShowPossibeMoves(_unit);
    }



    static IPossibleMovesCalculator _possibleMovesCalculator;
    static List<Cell> _shownMoves = new List<Cell>();
    static IGameBoard _gameBoard;
    Unit _unit;
}
