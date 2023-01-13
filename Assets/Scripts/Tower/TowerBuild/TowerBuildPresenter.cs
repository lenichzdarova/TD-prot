using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildPresenter
{
    private TowerBuildHandler _towerBuildHandler;
    private IBuildUIProvider _buildUIProvider;

    public TowerBuildPresenter(TowerBuildHandler towerBuildHandler, IBuildUIProvider buildUIProvider)
    {
        _towerBuildHandler = towerBuildHandler;
        _buildUIProvider = buildUIProvider;

        towerBuildHandler.BuildActivation += buildUIProvider.OnBuildActivation;
        buildUIProvider.BuildingIndexSelected += towerBuildHandler.OnTowerToBuildSelected;
        buildUIProvider.SellTower += towerBuildHandler.OnTowerSell;
    }
}
