using UnityEngine;

[RequireComponent(typeof(TowerFactory))]

public class GameBoard : MonoBehaviour
{
    [SerializeField] PlayerDamageZone _playerDamageZone;
    [SerializeField] Spawner[] _spawners;
    [SerializeField] Building[] _initialBuildings;    
    private TowerBuildHandler _towerBuildHandler;
    private TowerFactory _towerFactory;    

    public void Initialize(Health playerHealth, IPlayerGoldProvider iPlayerGoldProvider, IBuildUIProvider iBuildUIProvider)
    {
        InitializeSpawners();
        InitializeBuildingSystem(iPlayerGoldProvider,iBuildUIProvider);
        InitializePlayerDamageZone(playerHealth);       
    }
    
    private void InitializeSpawners()
    {
        foreach (var spawner in _spawners)
        {
            spawner.Initialize();
        }
    }

    private void InitializeBuildingSystem(IPlayerGoldProvider iPlayerGoldProvider, IBuildUIProvider iBuildUIProvider)
    {
        _towerFactory = GetComponent<TowerFactory>();
        _towerBuildHandler = new TowerBuildHandler(_towerFactory, iPlayerGoldProvider, _initialBuildings);
        new TowerBuildPresenter(_towerBuildHandler, iBuildUIProvider);
    }

    private void InitializePlayerDamageZone(Health playerHealth)
    {
        _playerDamageZone.Init(playerHealth);
    }
}
