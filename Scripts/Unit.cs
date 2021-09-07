using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Type
    {
        Black,
        White
    }
    public Type UnitType { get; private set; } = Type.White;
    int _numberOfMoves = 0;
    [SerializeField] Transform _model;

    public int GetNumberOfMoves() { return _numberOfMoves; }
    public Vector2Int GetPosition()
    {
        return new Vector2Int((int)(transform.position.x), (int)(transform.position.z));
    }
    public Vector2Int GetForward()
    {
        return new Vector2Int(0, (int)_model.forward.z);
    }
    public Vector2Int GetRight()
    {
        return Vector2Int.CeilToInt(_model.right);
    }
}
