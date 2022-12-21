using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuldingPresenter : MonoBehaviour
{
    private TowerBuildingHandler towerBuildingHandler;
    private IBuildUIProvider buildUIProvider;

    public TowerBuldingPresenter(TowerBuildingHandler towerBuildingHandler, IBuildUIProvider buildUIProvider)
    {
        this.towerBuildingHandler = towerBuildingHandler;
        this.buildUIProvider = buildUIProvider;

        towerBuildingHandler.buildActivation += buildUIProvider.InitializeBuildUI;
        buildUIProvider.buildingIndexSelected += towerBuildingHandler.OnUpgradeIndexSelected;
    }
}
