using UnityEngine;
using System.Collections.Generic;
using System;

public class UIHandler : MonoBehaviour, IBuildUIProvider
{
    public event Action<int> BuildingIndexSelected;
    public event Action SellTower;

    [SerializeField] private BuildUI buildUI;
    [SerializeField] private GoldUI goldUI;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private IngameMenuUI ingameMenuUI;
    private IPlayerGoldProvider playerGoldProvider;
    private Health _playerHealth;

    public void Initialize(IPlayerGoldProvider iPlayerGoldProvider, Health playerHealth)
    {
        playerGoldProvider = iPlayerGoldProvider;
        _playerHealth = playerHealth;
        //ingameMenuUI.Show();
        //goldUI.Init(iPlayerGoldProvider);
        //healthUI.Init(iPlayerHealthProvider);
        //buildUI.Hide();        
    }

    #region BuildUISection
    public void OnBuildActivation(Building[] buildings, int sellGoldAmount, bool canSell)
    {
        OpenBuildUI(buildings, sellGoldAmount, canSell);
    }

    private void OpenBuildUI(Building[] buildings, int sellGoldAmount, bool canSell)
    {
        buildUI.BuildingIndexSelected += OnBuildingIndexSelected;
        buildUI.SellTowerButtonClicked += OnSellTowerButtonClicked;
        buildUI.Initialize(playerGoldProvider, buildings, sellGoldAmount, canSell);
    }    

    private void OnBuildingIndexSelected(int index)
    {
        buildUI.BuildingIndexSelected -= OnBuildingIndexSelected;
        buildUI.SellTowerButtonClicked -= OnSellTowerButtonClicked;
        BuildingIndexSelected.Invoke(index);
        buildUI.Hide();
    }

    private void OnSellTowerButtonClicked()
    {
        buildUI.BuildingIndexSelected -= OnBuildingIndexSelected;
        buildUI.SellTowerButtonClicked -= OnSellTowerButtonClicked;
        SellTower?.Invoke();
        buildUI.Hide();
    }
    #endregion
}