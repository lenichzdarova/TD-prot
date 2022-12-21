using UnityEngine;

[RequireComponent(typeof(TowerFactory))]

public class GameBoard : MonoBehaviour
{   
    [SerializeField] Spawner[] spawners;
    [SerializeField] Building[] buildings;    
    private TowerBuildingHandler towerBuldingHandler;
    private TowerFactory towerFactory;

    [SerializeField] PlayerDamageZone playerDamageZone;
    private Building currentSelected;
    private float sellMultiplier;

    public void Initialize(IPlayerHealthProvider iPlayerHealthProvider,IBuildUIProvider iBuildUIProvider)
    {          
        foreach(var spawner in spawners) 
        {
            spawner.Initialize();
        } 
        towerFactory = GetComponent<TowerFactory>();
        towerBuldingHandler = new TowerBuildingHandler(towerFactory, iBuildUIProvider, buildings);
        playerDamageZone.Init(iPlayerHealthProvider);     
        //buildUI.OnBuild += BuildTower;
        //buildUI.OnSell += SellTower;
    }        
}
