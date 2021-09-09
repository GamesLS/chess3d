using System;
using System.Collections.Generic;
using UnityEngine;

public class KingPossibleMovesCalculator : BasePossibleMovesCalculator
{
    public KingPossibleMovesCalculator(IGameBoard gameBoard) : base(gameBoard) { }

    public override List<Vector2Int> Calculate(Unit unit)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();

        AddStraightDirections(unit, possibleMoves);
        AddDiagonalDirections(unit, possibleMoves);

        DeleteOppositeTeamKingMoves(unit, possibleMoves);

        return possibleMoves;
    }

    void AddStraightDirections(Unit unit, List<Vector2Int> possibleMoves)
    {
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward(), 1);
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward(), 1);
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetRight(), 1);
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetRight(), 1);
    }

    void AddDiagonalDirections(Unit unit, List<Vector2Int> possibleMoves)
    {
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward() + unit.Moving().GetRight(), 1);
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward() + unit.Moving().GetRight(), 1);
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward() - unit.Moving().GetRight(), 1);
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward() - unit.Moving().GetRight(), 1);
    }

    void DeleteOppositeTeamKingMoves(Unit unit, List<Vector2Int> possibleMoves)
    {
        Debug.Log("DeleteOppositeTeamKingMoves(Unit unit, List<Vector2Int> possibleMoves): implement me sempai!");
    }
}