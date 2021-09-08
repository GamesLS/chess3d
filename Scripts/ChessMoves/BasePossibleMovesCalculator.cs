using System.Collections.Generic;
using UnityEngine;

public abstract class BasePossibleMovesCalculator : IPossibleMovesCalculator
{
    public BasePossibleMovesCalculator(IGameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    public abstract List<Vector2Int> Calculate(Unit unit);

    protected void AddMoveIfThereEnemyUnit(Unit unit, Vector2Int move, List<Vector2Int> listOfMoves)
    {
        if(_gameBoard.IsMoveAvailable(move, unit)
            && _gameBoard.GetCell(move).IsOccupied()
            && (_gameBoard.GetCell(move).GetUnit().UnitType != unit.UnitType))
            listOfMoves.Add(move);
    }
    
    
    
    protected IGameBoard _gameBoard;
}
