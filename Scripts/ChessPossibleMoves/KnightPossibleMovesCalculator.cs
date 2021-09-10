using System.Collections.Generic;
using UnityEngine;

public class KnightPossibleMovesCalculator : BasePossibleMovesCalculator
{
    public KnightPossibleMovesCalculator(IGameBoard gameBoard) : base(gameBoard) { }

    public override ICollection<Vector2Int> Calculate(Unit unit)
    {
        ICollection<Vector2Int> possibleMoves = new List<Vector2Int>();

        Vector2Int position = unit.Moving().GetPosition();
        Vector2Int forward = unit.Moving().GetForward();
        Vector2Int right = unit.Moving().GetRight();

        possibleMoves.Add(position + forward * 2 + right);
        possibleMoves.Add(position + forward * 2 - right);
        
        possibleMoves.Add(position - forward * 2 + right);
        possibleMoves.Add(position - forward * 2 - right);

        possibleMoves.Add(position + forward + right * 2);
        possibleMoves.Add(position + forward - right * 2);
        
        possibleMoves.Add(position - forward + right * 2);
        possibleMoves.Add(position - forward - right * 2);

        return DeleteRestricted(unit, possibleMoves);
    }
}
