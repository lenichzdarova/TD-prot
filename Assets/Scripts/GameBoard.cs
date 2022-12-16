
using UnityEngine;

[RequireComponent(typeof(TowerFactory))]

public class GameBoard : MonoBehaviour
{   
    [SerializeField] Spawner[] spawners;
    [SerializeField] Building[] buildings;
    [SerializeField] BuildUI buildUI;
    
    private PlayerStats playerStats;
    private int initialGold = 100;
    private int initialHP = 100;
    
    private Controller controller;
    private Building currentSelected;
    private float sellMultiplier = 0.5f;


    public void Initialize(Controller controller)
    {        
        playerStats = new PlayerStats(initialHP, initialGold);
        this.controller = controller;
        foreach(var spawner in spawners) 
        {
            spawner.Initialize();
        }       
        foreach(var building in buildings)
        {
            building.OnBuild += OpenBuildUI;
        }
        controller.OnGoldChange += GoldCheck;
        buildUI.OnBuild += BuildTower;
        buildUI.OnSell += SellTower;

    }    

    private void OpenBuildUI(Building building)
    {
        currentSelected= building;
        bool canSell = currentSelected.CanSell();
        int sellAmount = canSell ? (int)(currentSelected.GetCost() * sellMultiplier) : 0;
        buildUI.SetSellAmount(sellAmount);
        Building[] upgrades = building.GetUpgrades();
        buildUI.gameObject.SetActive(true);
        buildUI.Initialize(canSell);        
        for (int i = 0; i < upgrades.Length; i++)
        {
            Building upgrade = upgrades[i];
            Sprite buttonIcon = upgrade.GetIcon();
            int cost = upgrade.GetCost();           
            bool enoughGold = controller.GetGold()>=upgrade.GetCost()?true:false;
            buildUI.ActivateButton(i, buttonIcon, cost,enoughGold);            
        }

        Camera cam = controller.GetCam();
        Vector3 position = cam.WorldToScreenPoint(currentSelected.transform.position);
        buildUI.transform.position = position;
        
    }  
    
    private void GoldCheck(int value)
    {
        if (currentSelected != null)
        {
            Building[] upgrades = currentSelected.GetUpgrades();

            for(int i =0;i< upgrades.Length;i++)
            {
                bool enoughGold = upgrades[i].GetCost()<=value?true:false;
                buildUI.GoldChange(i, enoughGold);
            }
        }
        
    }

    private void BuildTower(int index)
    {        
        Building building = currentSelected.GetUpgrades()[index];
        Vector3 position = currentSelected.transform.position;
        Quaternion rotation = currentSelected.transform.rotation;
        Building instance = Instantiate(building,position,rotation);
        controller.ChangeGold(-instance.GetCost());
        instance.OnBuild += OpenBuildUI;
        if(currentSelected.CanSell())
        {
            Destroy(currentSelected.gameObject);
        }
        
    }
    private void SellTower()
    {
        int towerCost = currentSelected.GetCost();
        int sellAmount = (int)(towerCost * sellMultiplier);
        controller.ChangeGold(sellAmount);
        Destroy(currentSelected.gameObject);
    }
}
