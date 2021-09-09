using UnityEngine;

public class GameCreator : MonoBehaviour
{
    void Start()
    {
        _blackRotation = Quaternion.Euler(0, 180, 0);
        CreateGame();
    }

    void CreateGame()
    {
        CreatePawns();
    }

    void CreateUnits(Cell[] spawns, GameObject prefab, Unit.Type type)
    {
        foreach (Cell cell in spawns)
        {
            Unit unit = Instantiate(prefab, _parent).GetComponent<Unit>();
            unit.ChangeType(type);

            Vector3 position = new Vector3(
                cell.GetPosition().x, _parent.transform.position.y, cell.GetPosition().y
                );
            unit.transform.position = position;

            if (type == Unit.Type.Black) unit.Moving().ApplyRotation(_blackRotation);

            unit.Moving().Init(cell, _gameBoard);
        }
    }

    void CreatePawns()
    {
        CreateUnits(_pawnsSpawnB, _pawn, Unit.Type.Black);
        CreateUnits(_pawnsSpawnW, _pawn, Unit.Type.White);
    }



    Quaternion _blackRotation;
    [SerializeField] ChessBoard _gameBoard;
    [SerializeField] Transform _parent;
    [SerializeField] Material _white;
    [SerializeField] Material _black;
    [SerializeField] GameObject _pawn;
    [SerializeField] Cell[] _pawnsSpawnW;
    [SerializeField] Cell[] _pawnsSpawnB;
}
