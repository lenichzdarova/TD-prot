using UnityEngine;
using System.Collections.Generic;
using System;

public class UIHandler : MonoBehaviour, IBuildUIProvider
{
    public event Action<int> buildingIndexSelected;

    [SerializeField] private BuildUI buildUI;
    [SerializeField] private GoldUI goldUI;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private IngameMenuUI ingameMenuUI;    

    public void Init(IPlayerGoldProvider iPlayerGoldProvider, IPlayerHealthProvider iPlayerHealthProvider)
    {
        //ingameMenuUI.Show();
        goldUI.Init(iPlayerGoldProvider);
        healthUI.Init(iPlayerHealthProvider);
        //buildUI.Hide();
        buildUI.buildingIndexSelected += OnBuildingIndexSelected;
    }

    public BuildUI GetBuildUI()
    {
       return buildUI;
    }

    public void InitializeBuildUI(Building[] buildings, int towerCost, bool canSell)
    {
        buildUI.Initialize(buildings,towerCost,canSell);
    }

    private void OnBuildingIndexSelected(int index)
    {
        buildingIndexSelected.Invoke(index);
        buildUI.Hide();
    }
}