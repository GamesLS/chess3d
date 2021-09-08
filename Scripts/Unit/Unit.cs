using UnityEngine;

public class Unit : MonoBehaviour
{
    public void ChangeType(Type type)
    {
        UnitType = type;
        _unitGFX.SetUnitType(this, type);
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

    public enum Type
    {
        Black,
        White
    }

    public Type UnitType { get; private set; } = Type.White;

    

    [SerializeField] UnitMoving _unitMoving;
    [SerializeField] UnitGFX _unitGFX;
    bool _isAlive = true;
}
