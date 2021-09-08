using UnityEngine;

public interface IMoveOnBoard
{
    public Vector2Int GetForward();
    public Vector2Int GetRight();
    public void Move(Vector2Int cell);
}
