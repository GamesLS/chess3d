using UnityEngine;

public class UnitMoving : BoardObject, IMoveOnBoard
{
    public void Init(Cell cell, IGameBoard gameBoard)
    {
        _positionCell = cell;
        _positionCell.PlaceUnit(_unit);

        if (_gameBoard == null) _gameBoard = gameBoard;
    }

    public void Move(Vector2Int position)
    {
        _positionCell.ForgiveUnit();
        _positionCell = _gameBoard.GetCell(position);
        _movingTarget = new Vector3(
            position.x, transform.position.y, position.y
            );
        _isNeedMove = true;
        _numberOfMoves++;
        _positionCell.PlaceUnit(_unit);
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



    static IGameBoard _gameBoard;
    Cell _positionCell;
    [SerializeField] Unit _unit;
    [SerializeField] Transform _model;
    [SerializeField] float _movingSpeed = .4f;

    #region Smooth moving
    bool _isNeedMove = false;
    Vector3 _movingTarget;
    Vector3 _currentVelocity; 
    #endregion

    int _numberOfMoves = 0;
}
