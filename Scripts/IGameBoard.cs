using UnityEngine;

public interface IGameBoard
{
    void Move(Unit unit, Vector2Int position);

    Cell GetCell(Vector2Int position);

    Vector2Int GetSize();
}
