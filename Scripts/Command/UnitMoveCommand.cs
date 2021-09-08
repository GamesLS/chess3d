using UnityEngine;

public class UnitMoveCommand : ICommand
{
    public UnitMoveCommand(Unit unit, Vector2Int movePosition)
    {
        _unit = unit;
        _movePosition = movePosition;
    }

    public void Execute()
    {
        _previousPosition = _unit.Moving().GetPosition();
        _unit.Moving().Move(_movePosition);
    }

    public void Undo()
    {
        _unit.Moving().ReduceNumberOfMoves();
        _unit.Moving().Move(_previousPosition);
        _unit.Moving().ReduceNumberOfMoves();
    }



    Unit _unit;
    Vector2Int _previousPosition;
    Vector2Int _movePosition;
}
