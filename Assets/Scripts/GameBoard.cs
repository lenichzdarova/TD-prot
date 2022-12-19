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

    public void Initialize(IPlayerDamage playerDamage,IBuildUIProvider iBuildUIProvider)
    {          
        foreach(var spawner in spawners) 
        {
            spawner.Initialize();
        } 
        towerFactory = GetComponent<TowerFactory>();
        towerBuldingHandler = new TowerBuildingHandler(towerFactory, iBuildUIProvider, buildings);
        playerDamageZone.Init(playerDamage);     
        //buildUI.OnBuild += BuildTower;
        //buildUI.OnSell += SellTower;
    }        
}
