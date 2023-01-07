using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildPresenter
{
    private TowerBuildHandler towerBuildHandler;
    private IBuildUIProvider buildUIProvider;

    public TowerBuildPresenter(TowerBuildHandler towerBuildHandler, IBuildUIProvider buildUIProvider)
    {
        this.towerBuildHandler = towerBuildHandler;
        this.buildUIProvider = buildUIProvider;

        towerBuildHandler.BuildActivation += buildUIProvider.OnBuildActivation;
        buildUIProvider.BuildingIndexSelected += towerBuildHandler.OnTowerToBuildSelected;
        buildUIProvider.SellTower += towerBuildHandler.OnTowerSell;
    }
}
