using UnityEngine;

public class UnitMoveCommand : ICommand
{
    public UnitMoveCommand(Unit unit, Vector2Int movePosition, Unit unitToKill = null)
    {
        _unit = unit;
        _movePosition = movePosition;
        _unitToKill = unitToKill;
    }

    public void Execute()
    {
        _previousPosition = _unit.Moving().GetPosition();
        _unit.Moving().Move(_movePosition);
        if (_unitToKill) _unitToKill.Death();
    }

    public void Undo()
    {
        _unit.Moving().ReduceNumberOfMoves();
        _unit.Moving().Move(_previousPosition);
        _unit.Moving().ReduceNumberOfMoves();

        if (_unitToKill)
        {
            _unitToKill.Alive();
            _unitToKill.Moving().Move(_movePosition);
            _unitToKill.Moving().ReduceNumberOfMoves();
        }
    }



    Unit _unit;
    Unit _unitToKill;
    Vector2Int _previousPosition;
    Vector2Int _movePosition;
}
