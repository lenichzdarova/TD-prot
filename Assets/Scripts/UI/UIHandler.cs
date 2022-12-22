using UnityEngine;
using System.Collections.Generic;
using System;

public class UIHandler : MonoBehaviour, IBuildUIProvider
{
    public event Action<int> buildingIndexSelected;
    public event Action sellTower;

    [SerializeField] private BuildUI buildUI;
    [SerializeField] private GoldUI goldUI;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private IngameMenuUI ingameMenuUI;
    private IPlayerGoldProvider playerGoldProvider;
    private IPlayerHealthProvider playerHealthProvider;

    public void Initialize(IPlayerGoldProvider iPlayerGoldProvider, IPlayerHealthProvider iPlayerHealthProvider)
    {
        playerGoldProvider = iPlayerGoldProvider;
        playerHealthProvider = iPlayerHealthProvider;
        //ingameMenuUI.Show();
        //goldUI.Init(iPlayerGoldProvider);
        //healthUI.Init(iPlayerHealthProvider);
        //buildUI.Hide();
        
        buildUI.buildingIndexSelected += OnBuildingIndexSelected;
        buildUI.sellTowerButtonClicked += OnSellTowerButtonClicked;
    }    

    private void OpenBuildUI(Building[] buildings, int sellGoldAmount, bool canSell)
    {
        buildUI.Initialize(playerGoldProvider, buildings, sellGoldAmount, canSell);
    }

    public void OnBuildActivation(Building[] buildings, int sellGoldAmount, bool canSell)
    {
        OpenBuildUI(buildings, sellGoldAmount, canSell);
    }

    private void OnBuildingIndexSelected(int index)
    {
        buildingIndexSelected.Invoke(index);
        buildUI.Hide();
    }

    private void OnSellTowerButtonClicked()
    {
        sellTower?.Invoke();
        buildUI.Hide();
    }
}