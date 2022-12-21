using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingHandler 
{
    public event Action<Building[], int, bool> buildActivation;

    private TowerFactory towerFactory;
    private Building currentSelectedBuilding;

    public TowerBuildingHandler(TowerFactory towerFactory, IBuildUIProvider iBuildUIProvider, Building[] initialBuildings)
    {
        this.towerFactory = towerFactory;        
        foreach(var building in initialBuildings)
        {
            building.BuildingClicked += OnBuildingClicked;
        }
        new TowerBuldingPresenter(this, iBuildUIProvider);
    } 
    
    private void OnBuildingClicked(Building clickedBuilding)
    {
        currentSelectedBuilding = clickedBuilding;
        buildActivation?.Invoke(currentSelectedBuilding.GetUpgrades(), currentSelectedBuilding.GetCost(), currentSelectedBuilding.CanSell());
    }

    public void OnUpgradeIndexSelected(int index)
    {

    }

    private void BuildTower(Building prefab)
    {
        Building building = towerFactory.GetBuilding(prefab);
        building.transform.position = currentSelectedBuilding.transform.position;
        building.BuildingClicked += OnBuildingClicked;
    }

    private void OnTowerToBuildSelected(int index)
    {
        Building prefab = currentSelectedBuilding.GetUpgrades()[index];
        BuildTower(prefab);
    }
}
