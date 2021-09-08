public class Cell : BoardObject
{
    public void PlaceUnit(Unit unit)
    {
        _unit = unit;
        _isOccupied = true;
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
        _unit = unit;
        _isActive = true;
    }

    public void Deactivate()
    {
        _gfx.Deactivate();
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
        if (_isActive && _unit != null)
        {
            _gameBoard.Move(_unit, this);
            UnitUI.HidePossibleMoves();
            // TODO: unit.cell.ForgiveUnit(); 
        }
    }



    static IGameBoard _gameBoard;
    bool _isActive = false;
    bool _isOccupied = false;
    Unit _unit;
    CellGFX _gfx;
}
