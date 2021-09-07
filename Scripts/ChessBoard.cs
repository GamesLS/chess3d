using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChessBoard : MonoBehaviour, IGameBoard
{
    [SerializeField] List<Cell> _cells = new List<Cell>();
    int _size = 8;

    public Cell GetCell(Vector2Int position)
    {
        return _cells.Where(cell => cell.GetPosition() == position).FirstOrDefault();
    }

    public Vector2Int GetSize()
    {
        return new Vector2Int(_size, _size);
    }

    public void Move(Unit unit, Vector2Int position)
    {
        
    }
}
