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
        CreateRoots();
    }

    void CreateUnits(Cell[] spawns, GameObject prefab, Unit.Team team, Unit.Type type)
    {
        foreach (Cell cell in spawns)
        {
            Unit unit = Instantiate(prefab, _parent).GetComponent<Unit>();
            unit.ChangeTeam(team);

            Vector3 position = new Vector3(
                cell.GetPosition().x, _parent.transform.position.y, cell.GetPosition().y
                );
            unit.transform.position = position;

            if (team == Unit.Team.Black) unit.Moving().ApplyRotation(_blackRotation);

            unit.Moving().Init(cell, _gameBoard);
            unit.ChangeType(type);
        }
    }

    void CreatePawns()
    {
        CreateUnits(_pawnsSpawnB, _pawn, Unit.Team.Black, Unit.Type.Pawn);
        CreateUnits(_pawnsSpawnW, _pawn, Unit.Team.White, Unit.Type.Pawn);
    }

    void CreateRoots()
    {
        CreateUnits(_rootsSpawnB, _root, Unit.Team.Black, Unit.Type.Root);
        CreateUnits(_rootsSpawnW, _root, Unit.Team.White, Unit.Type.Root);
    }



    Quaternion _blackRotation;
    [SerializeField] ChessBoard _gameBoard;
    [SerializeField] Transform _parent;
    [SerializeField] Material _white;
    [SerializeField] Material _black;
    [SerializeField] GameObject _pawn;
    [SerializeField] Cell[] _pawnsSpawnW;
    [SerializeField] Cell[] _pawnsSpawnB;
    [SerializeField] GameObject _root;
    [SerializeField] Cell[] _rootsSpawnW;
    [SerializeField] Cell[] _rootsSpawnB;
}
