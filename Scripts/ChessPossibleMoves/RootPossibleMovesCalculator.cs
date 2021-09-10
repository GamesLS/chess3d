using System.Collections.Generic;
using UnityEngine;

public class RootPossibleMovesCalculator : BasePossibleMovesCalculator
{
    public RootPossibleMovesCalculator(IGameBoard gameBoard) : base(gameBoard) { }

    public override ICollection<Vector2Int> Calculate(Unit unit)
    {
        ICollection<Vector2Int> possibleMoves = new List<Vector2Int>();
        
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward());
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward());
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetRight());
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetRight());

        return possibleMoves;
    }
}
