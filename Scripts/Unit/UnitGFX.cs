using UnityEngine;

public class UnitGFX : MonoBehaviour
{
    public void SetUnitType(Unit unit, Unit.Type type)
    {
        if (type == Unit.Type.Black)
            unit.GFX().SetMaterial(_black);
        else
            unit.GFX().SetMaterial(_white);
    }

    private void SetMaterial(Material mat)
    {
        _renderer.material = mat;
    }

    private void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }



    [SerializeField] Material _white;
    [SerializeField] Material _black;
    Renderer _renderer;
}
