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
        _movingStart = transform.position;
        _movingTarget = new Vector3(
            position.x, transform.position.y, position.y
            );
        _elapsedTime = 0f;
        _isNeedMove = true;
        _isSomebodyMovesRightNow = true;
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
    // TODO: rotation not response single responsibility
    public bool IsMoving { get { return _isSomebodyMovesRightNow; } }

    void Update()
    {
        if (_isNeedMove)
        {
            float progress = _elapsedTime / _movingSpeed;
            transform.position = Vector3.Lerp(_movingStart, _movingTarget, progress);

            if((_movingTarget - transform.position).sqrMagnitude <= 0.0001)
            {
                transform.position = _movingTarget;
                _isNeedMove = false;
                _isSomebodyMovesRightNow = false;
            }
            else
            {
                _elapsedTime += Time.deltaTime;
            }
        }
    }



    static bool _isSomebodyMovesRightNow = false;
    static IGameBoard _gameBoard;
    Cell _positionCell;
    [SerializeField] Unit _unit;
    [SerializeField] Transform _model;
    [SerializeField] float _movingSpeed = .4f;

    #region Smooth moving
    bool _isNeedMove = false;
    Vector3 _movingStart;
    Vector3 _movingTarget;
    float _elapsedTime = 0f; 
    #endregion

    int _numberOfMoves = 0;
}
