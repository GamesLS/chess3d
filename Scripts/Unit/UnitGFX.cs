using UnityEngine;

public class UnitGFX : MonoBehaviour
{
    public void SetUnitTeam(Unit unit, Unit.Team team)
    {
        if (team == Unit.Team.Black)
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
