using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildHandler
{
    public event Action<Building[], int, bool> BuildActivation;

    private TowerFactory towerFactory;
    private Building currentSelectedBuilding;
    private IPlayerGoldProvider playerGoldProvider;

    private float sellTowerGoldModifier = 0.7f;

    public TowerBuildHandler(TowerFactory towerFactory, IBuildUIProvider iBuildUIProvider, IPlayerGoldProvider iPlayerGoldProvider, Building[] initialBuildings)
    {
        this.towerFactory = towerFactory;
        playerGoldProvider= iPlayerGoldProvider;
        foreach(var building in initialBuildings)
        {
            building.BuildingClicked += OnBuildingClicked;
        }
        new TowerBuildPresenter(this, iBuildUIProvider);
    } 
    
    private void OnBuildingClicked(Building clickedBuilding)
    {
        currentSelectedBuilding = clickedBuilding;
        BuildActivation?.Invoke(currentSelectedBuilding.GetUpgrades(), GetTowerSellRevenue(), currentSelectedBuilding.CanSell());
    }    

    private void BuildTower(Building prefab)
    {
        playerGoldProvider.AddGold(-prefab.GetCost());
        Building building = towerFactory.GetBuilding(prefab);
        building.transform.position = currentSelectedBuilding.transform.position;
        building.BuildingClicked += OnBuildingClicked;
        if (currentSelectedBuilding.CanSell())
        {
            towerFactory.Recycle(currentSelectedBuilding);
        }        
    }

    public void OnTowerToBuildSelected(int index)
    {
        Building prefab = currentSelectedBuilding.GetUpgrades()[index];
        BuildTower(prefab);
    }

    public void OnTowerSell()
    {
        playerGoldProvider.AddGold(GetTowerSellRevenue());
        towerFactory.Recycle(currentSelectedBuilding);        
    }

    private int GetTowerSellRevenue()
    {
        int towerCost = currentSelectedBuilding.GetCost();
        int towerSellRevenue = (int)(towerCost * sellTowerGoldModifier);
        return towerSellRevenue;
    }
}
