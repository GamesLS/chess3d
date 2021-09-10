using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KingPossibleMovesCalculator : BasePossibleMovesCalculator
{
    public KingPossibleMovesCalculator(IGameBoard gameBoard) : base(gameBoard) { }

    public override ICollection<Vector2Int> Calculate(Unit unit, bool onlyKillMoves = false)
    {
        ICollection<Vector2Int> possibleMoves = new List<Vector2Int>();

        AddStraightDirections(unit, possibleMoves);
        AddDiagonalDirections(unit, possibleMoves);

        DeleteOppositeTeamKingMoves(unit, possibleMoves);

        return possibleMoves;
    }

    void AddStraightDirections(Unit unit, ICollection<Vector2Int> possibleMoves)
    {
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward(), 1);
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward(), 1);
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetRight(), 1);
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetRight(), 1);
    }

    void AddDiagonalDirections(Unit unit, ICollection<Vector2Int> possibleMoves)
    {
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward() + unit.Moving().GetRight(), 1);
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward() + unit.Moving().GetRight(), 1);
        CastRayToDirection(unit, possibleMoves, unit.Moving().GetForward() - unit.Moving().GetRight(), 1);
        CastRayToDirection(unit, possibleMoves, -unit.Moving().GetForward() - unit.Moving().GetRight(), 1);
    }

    void DeleteOppositeTeamKingMoves(Unit unit, ICollection<Vector2Int> possibleMoves)
    {
        Unit enemyKing = _gameBoard.GetUnit(Unit.Type.King)
            .Where(u => u.UnitTeam != unit.UnitTeam).First();
        Vector2Int ekPosition = enemyKing.Moving().GetPosition();
        Vector2Int forward = enemyKing.Moving().GetForward();
        Vector2Int right = enemyKing.Moving().GetRight();

        ICollection<Vector2Int> enemyKingMoves = new List<Vector2Int>();

        enemyKingMoves.Add(ekPosition + forward);
        enemyKingMoves.Add(ekPosition - forward);
        enemyKingMoves.Add(ekPosition + right);
        enemyKingMoves.Add(ekPosition - right);

        enemyKingMoves.Add(ekPosition + forward + right);
        enemyKingMoves.Add(ekPosition + forward - right);
        enemyKingMoves.Add(ekPosition - forward + right);
        enemyKingMoves.Add(ekPosition - forward - right);

        foreach (Vector2Int ekMove in enemyKingMoves)
            possibleMoves.Remove(ekMove);
    }
}