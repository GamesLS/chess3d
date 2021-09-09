using System.Collections.Generic;
using UnityEngine;

public abstract class BasePossibleMovesCalculator : IPossibleMovesCalculator
{
    public BasePossibleMovesCalculator(IGameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    public abstract List<Vector2Int> Calculate(Unit unit);

    protected void AddMoveIfThereEnemyUnit(Unit unit, Vector2Int move, List<Vector2Int> listOfMoves)
    {
        if (_gameBoard.IsMoveAvailable(move, unit)
            && _gameBoard.GetCell(move).IsOccupied()
            && (_gameBoard.GetCell(move).GetUnit().UnitTeam != unit.UnitTeam))
            listOfMoves.Add(move);
    }

    protected List<Vector2Int> DeleteRestricted(Unit unit, List<Vector2Int> possibleMoves)
    {
        List<Vector2Int> availableMoves = new List<Vector2Int>();
        availableMoves.AddRange(possibleMoves);
        foreach (Vector2Int move in possibleMoves)
        {
            if (!_gameBoard.IsMoveAvailable(move, unit))
                availableMoves.Remove(move);
        }

        return availableMoves;
    }

    protected void CastRayToDirection(Unit unit, List<Vector2Int> possibleMoves, Vector2Int direction, int maxDistance = 8)
    {
        for (int distance = 1; distance <= maxDistance; distance++)
        {
            Vector2Int move = unit.Moving().GetPosition() + direction * distance;

            if (!_gameBoard.IsMoveAvailable(move, unit))
                return;

            possibleMoves.Add(move);

            if (_gameBoard.GetCell(move).IsOccupied())
                return;
        }
    }



    protected IGameBoard _gameBoard;
}
