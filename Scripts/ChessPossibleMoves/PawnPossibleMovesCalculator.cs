using System.Collections.Generic;
using UnityEngine;

public class PawnPossibleMovesCalculator : BasePossibleMovesCalculator
{
    public PawnPossibleMovesCalculator(IGameBoard gameBoard) : base(gameBoard) { }

    public override ICollection<Vector2Int> Calculate(Unit unit, bool onlyKillMoves)
    {
        ICollection<Vector2Int> possibleMoves = new List<Vector2Int>();
        
        if (!onlyKillMoves) AddForwardMoves(unit, possibleMoves);
        AddDiagonalMoves(unit, possibleMoves, onlyKillMoves);

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

    void AddDiagonalMoves(Unit unit, ICollection<Vector2Int> possibleMoves, bool onlyKillMoves)
    {
        Vector2Int forward = unit.Moving().GetPosition() + unit.Moving().GetForward();
        Vector2Int right = unit.Moving().GetRight();

        Vector2Int diagonalRight = forward + right;
        if (onlyKillMoves) possibleMoves.Add(diagonalRight);
        else AddMoveIfThereEnemyUnit(unit, diagonalRight, possibleMoves);

        Vector2Int diagonalLeft = forward - right;
        if (onlyKillMoves) possibleMoves.Add(diagonalLeft);
        else AddMoveIfThereEnemyUnit(unit, diagonalLeft, possibleMoves);
    }
}
