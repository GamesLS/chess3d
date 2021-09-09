using System.Collections.Generic;
using UnityEngine;

public class RootPossibleMovesCalculator : BasePossibleMovesCalculator
{
    public RootPossibleMovesCalculator(IGameBoard gameBoard) : base(gameBoard) { }

    public override List<Vector2Int> Calculate(Unit unit)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();
        Debug.Log(unit.GetInstanceID());
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward());
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward());
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetRight());
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetRight());

        return possibleMoves;
    }
}
