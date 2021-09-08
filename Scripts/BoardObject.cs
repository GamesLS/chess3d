using UnityEngine;

public abstract class BoardObject : MonoBehaviour
{
    public Vector2Int GetPosition()
    {
        return new Vector2Int((int)(transform.position.x), (int)(transform.position.z));
    }
}
