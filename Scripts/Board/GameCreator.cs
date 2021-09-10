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
        CreateKnights();
        CreateBishops();
        CreateQueens();
        CreateKings();
    }

    void CreateUnits(Cell[] spawns, GameObject prefab, Unit.Team team, Unit.Type type)
    {
        foreach (Cell cell in spawns)
        {
            Unit unit = Instantiate(prefab, _parent).GetComponent<Unit>();
            unit.ChangeTeam(team);
            unit.ChangeType(type);
            unit.Moving().Init(cell, _gameBoard);

            Vector3 position = new Vector3(cell.GetPosition().x, _parent.transform.position.y, cell.GetPosition().y);
            unit.transform.position = position;

            if (team == Unit.Team.Black) unit.Moving().ApplyRotation(_blackRotation);

            _gameBoard.AddUnit(unit);
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

    void CreateKnights()
    {
        CreateUnits(_knightsSpawnB, _knight, Unit.Team.Black, Unit.Type.Knight);
        CreateUnits(_knightsSpawnW, _knight, Unit.Team.White, Unit.Type.Knight);
    }

    void CreateBishops()
    {
        CreateUnits(_bishopsSpawnB, _bishop, Unit.Team.Black, Unit.Type.Bishop);
        CreateUnits(_bishopsSpawnW, _bishop, Unit.Team.White, Unit.Type.Bishop);
    }

    void CreateQueens()
    {
        CreateUnits(_queenSpawnB, _queen, Unit.Team.Black, Unit.Type.Queen);
        CreateUnits(_queenSpawnW, _queen, Unit.Team.White, Unit.Type.Queen);
    }

    void CreateKings()
    {
        CreateUnits(_kingSpawnB, _king, Unit.Team.Black, Unit.Type.King);
        CreateUnits(_kingSpawnW, _king, Unit.Team.White, Unit.Type.King);
    }



    Quaternion _blackRotation;
    [SerializeField] ChessBoard _gameBoard;
    [SerializeField] Transform _parent;

    [SerializeField] GameObject _pawn;
    [SerializeField] Cell[] _pawnsSpawnW;
    [SerializeField] Cell[] _pawnsSpawnB;
    [SerializeField] GameObject _root;
    [SerializeField] Cell[] _rootsSpawnW;
    [SerializeField] Cell[] _rootsSpawnB;
    [SerializeField] GameObject _knight;
    [SerializeField] Cell[] _knightsSpawnW;
    [SerializeField] Cell[] _knightsSpawnB;
    [SerializeField] GameObject _bishop;
    [SerializeField] Cell[] _bishopsSpawnW;
    [SerializeField] Cell[] _bishopsSpawnB;
    [SerializeField] GameObject _queen;
    [SerializeField] Cell[] _queenSpawnW;
    [SerializeField] Cell[] _queenSpawnB;
    [SerializeField] GameObject _king;
    [SerializeField] Cell[] _kingSpawnW;
    [SerializeField] Cell[] _kingSpawnB;
}
