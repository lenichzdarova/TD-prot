using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingHandler 
{
    private TowerFactory towerFactory;
    private IBuildUIProvider iBuildUIProvider;

    public TowerBuildingHandler(TowerFactory towerFactory, IBuildUIProvider iBuildUIProvider, Building[] initialBuildings)
    {
        this.towerFactory = towerFactory;
        this.iBuildUIProvider= iBuildUIProvider;
        foreach(var building in initialBuildings)
        {
            building.OnBuildingClicked += iBuildUIProvider.InitializeBuildUI;
        }
    }
}
