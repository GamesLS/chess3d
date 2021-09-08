using System.Collections.Generic;
using UnityEngine;

public class PawnPossibleMovesCalculator : BasePossibleMovesCalculator
{
    public PawnPossibleMovesCalculator(IGameBoard gameBoard) : base(gameBoard) { }

    public override List<Vector2Int> Calculate(Unit unit)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        AddForwardMoves(unit, possibleMoves);
        AddDiagonalMoves(unit, possibleMoves);

        return DeleteRestricted(unit, possibleMoves);
    }

    static void AddForwardMoves(Unit unit, List<Vector2Int> possibleMoves)
    {
        possibleMoves.Add(unit.Moving().GetPosition() + unit.Moving().GetForward());
        if (unit.Moving().GetNumberOfMoves() == 0)
            possibleMoves.Add(unit.Moving().GetPosition() + unit.Moving().GetForward() * 2);
    }

    void AddDiagonalMoves(Unit unit, List<Vector2Int> possibleMoves)
    {
        Vector2Int forward = unit.Moving().GetPosition() + unit.Moving().GetForward();
        Vector2Int right = unit.Moving().GetRight();

        Vector2Int diagonalRight = forward + right;
        AddMoveIfThereEnemyUnit(unit, diagonalRight, possibleMoves);

        Vector2Int diagonalLeft = forward - right;
        AddMoveIfThereEnemyUnit(unit, diagonalLeft, possibleMoves);
    }

    List<Vector2Int> DeleteRestricted(Unit unit, List<Vector2Int> possibleMoves)
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
}
