using UnityEngine;

public interface IGameBoard
{
    void Move(Unit unit, Cell cell);

    void UndoMove();

    bool IsMoveAvailable(Vector2Int move, Unit unit);

    Cell GetCell(Vector2Int position);
}
