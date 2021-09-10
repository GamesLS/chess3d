using System.Collections.Generic;
using UnityEngine;

public class QueenPossibleMovesCalculator : BasePossibleMovesCalculator
{
    public QueenPossibleMovesCalculator(IGameBoard gameBoard) : base(gameBoard) { }

    public override ICollection<Vector2Int> Calculate(Unit unit, bool onlyKillMoves = false)
    {
        ICollection<Vector2Int> possibleMoves = new List<Vector2Int>();

        AddStraightDirections(unit, possibleMoves);
        AddDiagonalDirections(unit, possibleMoves);

        return possibleMoves;
    }

    void AddStraightDirections(Unit unit, ICollection<Vector2Int> possibleMoves)
    {
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward());
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward());
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetRight());
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetRight());
    }

    void AddDiagonalDirections(Unit unit, ICollection<Vector2Int> possibleMoves)
    {
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward() + unit.Moving().GetRight());
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward() + unit.Moving().GetRight());
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward() - unit.Moving().GetRight());
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward() - unit.Moving().GetRight());
    }
}