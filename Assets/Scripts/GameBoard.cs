using UnityEngine;

[RequireComponent(typeof(TowerFactory))]

public class GameBoard : MonoBehaviour
{   
    [SerializeField] Spawner[] spawners;
    [SerializeField] Building[] buildings;    
    private TowerBuildHandler towerBuildHandler;
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
        towerBuildHandler = new TowerBuildHandler(towerFactory, iBuildUIProvider, buildings);
        playerDamageZone.Init(iPlayerHealthProvider);     
        //buildUI.OnBuild += BuildTower;
        //buildUI.OnSell += SellTower;
    }        
}
