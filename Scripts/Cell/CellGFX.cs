using UnityEngine;

public class CellGFX : MonoBehaviour
{
    void Start()
    {
        _nativeMaterial = _renderer.material;
    }

    public void Activate()
    {
        if (_renderer.material.name == "Black (Instance)") _renderer.material = _materials._activeBlack;
        else _renderer.material = _materials._activeWhite;
    }

    public void Deactivate()
    {
        _renderer.material = _nativeMaterial;
    }

    public void MouseEnterThenActive()
    {
        if (_renderer.material.name == "ActiveBlack (Instance)")
            _renderer.material = _materials._activeHoverBlack;
        else
            _renderer.material = _materials._activeHoverWhite;
    }

    public void MouseLeaveThenActive()
    {
        if (_renderer.material.name == "ActiveHoverBlack (Instance)")
            _renderer.material = _materials._activeBlack;
        else
            _renderer.material = _materials._activeWhite;
    }
    
    
    
    [SerializeField] Renderer _renderer;
    [SerializeField] CellMaterialData _materials;
    Material _nativeMaterial;
}
