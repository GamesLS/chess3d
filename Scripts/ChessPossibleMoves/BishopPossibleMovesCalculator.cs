using System.Collections.Generic;
using UnityEngine;

public class BishopPossibleMovesCalculator : BasePossibleMovesCalculator
{
    public BishopPossibleMovesCalculator(IGameBoard gameBoard) : base(gameBoard) { }

    public override ICollection<Vector2Int> Calculate(Unit unit)
    {
        ICollection<Vector2Int> possibleMoves = new List<Vector2Int>();

        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward() + unit.Moving().GetRight());
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward() + unit.Moving().GetRight());
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward() - unit.Moving().GetRight());
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward() - unit.Moving().GetRight());

        return possibleMoves;
    }
}