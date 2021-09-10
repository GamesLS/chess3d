using System.Collections.Generic;
using UnityEngine;

public class PawnPossibleMovesCalculator : BasePossibleMovesCalculator
{
    public PawnPossibleMovesCalculator(IGameBoard gameBoard) : base(gameBoard) { }

    public override ICollection<Vector2Int> Calculate(Unit unit)
    {
        ICollection<Vector2Int> possibleMoves = new List<Vector2Int>();

        AddForwardMoves(unit, possibleMoves);
        AddDiagonalMoves(unit, possibleMoves);

        return DeleteRestricted(unit, possibleMoves);
    }

    void AddForwardMoves(Unit unit, ICollection<Vector2Int> possibleMoves)
    {
        Vector2Int forward = unit.Moving().GetPosition() + unit.Moving().GetForward();
        if (_gameBoard.GetCell(forward).IsOccupied())
            return;
        possibleMoves.Add(forward);

        if (unit.Moving().GetNumberOfMoves() == 0)
        {
            Vector2Int doubleForward = unit.Moving().GetPosition() + unit.Moving().GetForward() * 2;
            if (_gameBoard.GetCell(doubleForward).IsOccupied())
                return;
            possibleMoves.Add(doubleForward);
        }
    }

    void AddDiagonalMoves(Unit unit, ICollection<Vector2Int> possibleMoves)
    {
        Vector2Int forward = unit.Moving().GetPosition() + unit.Moving().GetForward();
        Vector2Int right = unit.Moving().GetRight();

        Vector2Int diagonalRight = forward + right;
        AddMoveIfThereEnemyUnit(unit, diagonalRight, possibleMoves);

        Vector2Int diagonalLeft = forward - right;
        AddMoveIfThereEnemyUnit(unit, diagonalLeft, possibleMoves);
    }
}
