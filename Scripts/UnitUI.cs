using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUI : MonoBehaviour
{
    Unit _unit;
    IPossibleMovesCalculator _possibleMovesCalculator;
    IGameBoard _gameBoard;
    bool _isPossibleMovesVisible = false;
    List<Cell> _shownMoves = new List<Cell>();

    private void Start()
    {
        _unit = GetComponent<Unit>();
        _gameBoard = FindObjectOfType<ChessBoard>();
        _possibleMovesCalculator = new PawnPossibleMovesCalculator(_gameBoard);
    }

    private void OnMouseDown()
    {
        if (_isPossibleMovesVisible)
            HidePossibleMoves();
        else
            ShowPossibeMoves();

        _isPossibleMovesVisible = !_isPossibleMovesVisible;
    }

    private void ShowPossibeMoves()
    {
        List<Vector2Int> movesCoord = _possibleMovesCalculator.Calculate(_unit);
        foreach (Vector2Int coord in movesCoord)
        {
            Cell cellToMove = _gameBoard.GetCell(coord);
            cellToMove.Activate(_unit);
            _shownMoves.Add(cellToMove);
        }
    }

    private void HidePossibleMoves()
    {
        foreach (Cell cell in _shownMoves)
            cell.Deactivate();
    }
}
