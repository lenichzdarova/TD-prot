using UnityEngine;
using System.Collections.Generic;
using System;

public class UIHandler : MonoBehaviour, IBuildUIProvider
{
    public event Action<int> BuildingIndexSelected;
    public event Action SellTower;

    [SerializeField] private BuildUI _buildUI;
    [SerializeField] private GoldUI _goldUI;
    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private IngameMenuUI _ingameMenuUI;
    private IPlayerGoldProvider _playerGoldProvider;
    private Health _playerHealth;

    public void Initialize(IPlayerGoldProvider iPlayerGoldProvider, Health playerHealth)
    {
        _playerGoldProvider = iPlayerGoldProvider;
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
        _buildUI.BuildingIndexSelected += OnBuildingIndexSelected;
        _buildUI.SellTowerButtonClicked += OnSellTowerButtonClicked;
        _buildUI.Initialize(_playerGoldProvider, buildings, sellGoldAmount, canSell);
    }    

    private void OnBuildingIndexSelected(int index)
    {
        _buildUI.BuildingIndexSelected -= OnBuildingIndexSelected;
        _buildUI.SellTowerButtonClicked -= OnSellTowerButtonClicked;
        BuildingIndexSelected.Invoke(index);
        _buildUI.Hide();
    }

    private void OnSellTowerButtonClicked()
    {
        _buildUI.BuildingIndexSelected -= OnBuildingIndexSelected;
        _buildUI.SellTowerButtonClicked -= OnSellTowerButtonClicked;
        SellTower?.Invoke();
        _buildUI.Hide();
    }
    #endregion
}