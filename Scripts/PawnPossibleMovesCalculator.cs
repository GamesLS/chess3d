using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPossibleMovesCalculator : IPossibleMovesCalculator
{
    IGameBoard _gameBoard;

    public PawnPossibleMovesCalculator(IGameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    public List<Vector2Int> Calculate(Unit unit)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        AddForwardMoves(unit, possibleMoves);
        AddDiagonalMoves(unit, possibleMoves);

        return DeleteRestricted(unit, possibleMoves);
    }

    private List<Vector2Int> DeleteRestricted(Unit unit, List<Vector2Int> possibleMoves)
    {
        List<Vector2Int> availableMoves = new List<Vector2Int>();
        availableMoves.AddRange(possibleMoves);
        foreach (Vector2Int move in possibleMoves)
        {
            if (!IsMoveValid(move, unit))
                availableMoves.Remove(move);
        }

        return availableMoves;
    }

    private static void AddForwardMoves(Unit unit, List<Vector2Int> possibleMoves)
    {
        possibleMoves.Add(unit.GetPosition() + unit.GetForward());
        if (unit.GetNumberOfMoves() == 0)
            possibleMoves.Add(unit.GetPosition() + unit.GetForward() * 2);
    }

    private static void AddDiagonalMoves(Unit unit, List<Vector2Int> possibleMoves)
    {
        possibleMoves.Add(unit.GetPosition() + unit.GetForward() + unit.GetRight());
        possibleMoves.Add(unit.GetPosition() + unit.GetForward() - unit.GetRight());
    }

    private bool IsMoveValid(Vector2Int move, Unit unit)
    {
        if (move.x >= _gameBoard.GetSize().x || move.y >= _gameBoard.GetSize().y
            || move.x < 0 || move.y < 0)
            return false;
        else if (_gameBoard.GetCell(move).IsOccupied()
            && (_gameBoard.GetCell(move).GetUnit().UnitType == unit.UnitType))
            return false;
        else
            return true;
    }
}
