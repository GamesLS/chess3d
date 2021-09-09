public class Cell : BoardObject
{
    public void PlaceUnit(Unit unit)
    {
        _unit = unit;
        _isOccupied = true;
    }

    public void ForgiveUnit()
    {
        _unit = null;
        _isOccupied = false;
    }

    public Unit GetUnit()
    {
        return _unit;
    }

    public bool IsOccupied()
    {
        return _isOccupied;
    }

    public void Activate(Unit unit)
    {
        _gfx.Activate();
        _possibleUnit = unit;
        _isActive = true;
    }

    public void Deactivate()
    {
        _gfx.Deactivate();
        _possibleUnit = null;
        _isActive = false;
    }

    void Start()
    {
        _gfx = GetComponent<CellGFX>();

        if (_gameBoard == null)
            _gameBoard = FindObjectOfType<ChessBoard>();
    }

    void OnMouseEnter()
    {
        if (_isActive)
        {
            _gfx.MouseEnterThenActive();
        }
    }

    void OnMouseExit()
    {
        if (_isActive)
        {
            _gfx.MouseLeaveThenActive();
        }
    }

    void OnMouseDown()
    {
        if (_isActive && _possibleUnit != null)
        {
            _gameBoard.Move(_possibleUnit, this);
            UnitUI.HidePossibleMoves();
            ChessBoard.WhoseMove = ChessBoard.WhoseMove == Unit.Team.White ? Unit.Team.Black : Unit.Team.White;
        }
    }



    static IGameBoard _gameBoard;
    bool _isActive = false;
    bool _isOccupied = false;
    Unit _possibleUnit;
    Unit _unit;
    CellGFX _gfx;
}
