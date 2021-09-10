using System.Collections.Generic;
using UnityEngine;

public interface IPossibleMovesCalculator
{
    ICollection<Vector2Int> Calculate(Unit unit, bool onlyKillMoves = false);
}
