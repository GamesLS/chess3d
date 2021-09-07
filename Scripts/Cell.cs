using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    bool isActive = false;
    bool _isOccupied = false;
    Unit _unit;
    CellGFX _gfx;

    private void Start()
    {
        _gfx = GetComponent<CellGFX>();
    }

    public Unit GetUnit()
    {
        return _unit;
    }

    public Vector2Int GetPosition()
    {
        return new Vector2Int((int)(transform.position.x), (int)(transform.position.z));
    }

    public bool IsOccupied()
    {
        return _isOccupied;
    }

    public void Activate(Unit unit)
    {
        _gfx.Activate();
        _unit = unit;
        isActive = true;
    }

    public void Deactivate()
    {
        _gfx.Deactivate();
        _unit = null;
        isActive = false;
    }

    private void OnMouseEnter()
    {
        if (isActive)
        {
            _gfx.MouseEnterThenActive();
        }
    }

    private void OnMouseExit()
    {
        if (isActive)
        {
            _gfx.MouseLeaveThenActive();
        }
    }
}
