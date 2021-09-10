using UnityEngine;

public class Unit : MonoBehaviour
{
    public void ChangeTeam(Team team)
    {
        UnitTeam = team;
        _unitGFX.SetUnitTeam(this, team);
    }

    public void ChangeType(Type type)
    {
        UnitType = type;
        _unitUI.ChangeType(type);
    }

    public void Death()
    {
        _isAlive = false;
        gameObject.SetActive(false);
    }

    public void Alive()
    {
        _isAlive = true;
        gameObject.SetActive(true);
    }

    public bool IsAlive()
    {
        return _isAlive;
    }

    public UnitMoving Moving()
    {
        return _unitMoving;
    }

    public UnitGFX GFX()
    {
        return _unitGFX;
    }

    public enum Team
    {
        Black,
        White
    }

    public Team UnitTeam { get; private set; }

    public enum Type
    {
        Pawn,
        Root,
        Knight,
        Bishop,
        Queen,
        King
    }

    public Type UnitType { get; private set; }

    public UnitUI UI { get { return _unitUI; } private set { _unitUI = value; } }



    [SerializeField] UnitMoving _unitMoving;
    [SerializeField] UnitUI _unitUI;
    [SerializeField] UnitGFX _unitGFX;
    bool _isAlive = true;
}
