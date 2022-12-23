using UnityEngine;

[RequireComponent(typeof(TowerFactory))]

public class GameBoard : MonoBehaviour
{
    [SerializeField] PlayerDamageZone playerDamageZone;
    [SerializeField] Spawner[] spawners;
    [SerializeField] Building[] initialBuildings;    
    private TowerBuildHandler towerBuildHandler;
    private TowerFactory towerFactory;    

    public void Initialize(IPlayerHealthProvider iPlayerHealthProvider, IPlayerGoldProvider iPlayerGoldProvider, IBuildUIProvider iBuildUIProvider)
    {          
        foreach(var spawner in spawners) 
        {
            spawner.Initialize();
        } 
        towerFactory = GetComponent<TowerFactory>();
        towerBuildHandler = new TowerBuildHandler(towerFactory, iBuildUIProvider, iPlayerGoldProvider, initialBuildings);
        playerDamageZone.Init(iPlayerHealthProvider);        
    }        
}
