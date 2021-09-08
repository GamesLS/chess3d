using UnityEngine;

public class UnitMoving : BoardObject, IMoveOnBoard
{
    public void Move(Vector2Int cell)
    {
        _movingTarget = new Vector3(cell.x, transform.position.y, cell.y);
        _isNeedMove = true;
        _numberOfMoves++;
    }

    public Vector2Int GetForward()
    {
        return new Vector2Int(0, (int)_model.forward.z);
    }

    public Vector2Int GetRight()
    {
        return Vector2Int.CeilToInt(_model.right);
    }

    public int GetNumberOfMoves()
    {
        return _numberOfMoves;
    }

    public void ReduceNumberOfMoves()
    {
        _numberOfMoves--;
    }

    public void ApplyRotation(Quaternion rotation)
    {
        _model.rotation *= rotation;
    }
    // TODO: rotation not response S from Solid
    void Update()
    {
        if (_isNeedMove)
        {
            transform.position = Vector3.SmoothDamp(
                transform.position, _movingTarget, ref _currentVelocity, _movingSpeed
                ); 

            if((_movingTarget - transform.position).sqrMagnitude <= 0.0001)
            {
                transform.position = _movingTarget;
                _isNeedMove = false;
            }
        }
    }



    [SerializeField] Transform _model;
    [SerializeField] float _movingSpeed = .4f;

    #region Smooth moving
    bool _isNeedMove = false;
    Vector3 _movingTarget;
    Vector3 _currentVelocity; 
    #endregion

    int _numberOfMoves = 0;
}
