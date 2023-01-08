using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildHandler
{
    public event Action<Building[], int, bool> BuildActivation;

    private TowerFactory _towerFactory;
    private Building _currentSelectedBuilding;
    private IPlayerGoldProvider _playerGoldProvider;

    private float _sellTowerGoldModifier = 0.7f;

    public TowerBuildHandler(TowerFactory towerFactory, IPlayerGoldProvider iPlayerGoldProvider, Building[] initialBuildings)
    {
        _towerFactory = towerFactory;
        _playerGoldProvider = iPlayerGoldProvider;
        foreach(var building in initialBuildings)
        {
            building.BuildingClicked += OnBuildingClicked;
        }        
    } 
    
    private void OnBuildingClicked(Building clickedBuilding)
    {
        _currentSelectedBuilding = clickedBuilding;
        BuildActivation?.Invoke(_currentSelectedBuilding.GetUpgrades(), GetTowerSellRevenue(), _currentSelectedBuilding.CanSell());
    }    

    private void BuildTower(Building prefab)
    {
        _playerGoldProvider.RemoveGold(prefab.GetCost());
        Building building = _towerFactory.GetBuilding(prefab);
        building.transform.position = _currentSelectedBuilding.transform.position;
        building.BuildingClicked += OnBuildingClicked;
        if (_currentSelectedBuilding.CanSell())
        {
            _towerFactory.Recycle(_currentSelectedBuilding);
        }        
    }

    public void OnTowerToBuildSelected(int index)
    {
        Building prefab = _currentSelectedBuilding.GetUpgrades()[index];
        BuildTower(prefab);
    }

    public void OnTowerSell()
    {
        _playerGoldProvider.AddGold(GetTowerSellRevenue());
        _towerFactory.Recycle(_currentSelectedBuilding);        
    }

    private int GetTowerSellRevenue()
    {
        int towerCost = _currentSelectedBuilding.GetCost();
        int towerSellRevenue = (int)(towerCost * _sellTowerGoldModifier);
        return towerSellRevenue;
    }
}
