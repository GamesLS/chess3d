using System.Collections.Generic;
using UnityEngine;

public interface IPossibleMovesCalculator
{
    List<Vector2Int> Calculate(Unit unit);
}
