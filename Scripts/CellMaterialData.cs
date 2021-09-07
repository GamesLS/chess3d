using UnityEngine;

[CreateAssetMenu(fileName = "New Cell", menuName = "CellMaterial")]
public class CellMaterialData : ScriptableObject
{
    public Material _activeWhite;
    public Material _activeHoverWhite;
    public Material _activeBlack;
    public Material _activeHoverBlack;
    public Material _white;
    public Material _black;
}
