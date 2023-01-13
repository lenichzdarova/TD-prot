using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour
{
    public event Action<int> BuildingIndexSelected;
    public event Action SellTowerButtonClicked;

    [SerializeField] SelectTowerButton[] _selectTowerButtons;       
    [SerializeField] SellTowerButton _sellTowerButton;    
    [SerializeField] CloseButtonUI _closeBuildMenuButton;
    private IPlayerGoldProvider _playerGoldProvider;

    public void Initialize(IPlayerGoldProvider iplayerGoldProvider, Building[] buildings, int sellGoldAmount, bool canSell)
    {
        Show();
        _playerGoldProvider = iplayerGoldProvider;
        for (int i = 0; i < buildings.Length; i++)
        {
            SelectTowerButton button = _selectTowerButtons[i];
            button.Initialize(buildings[i],i,_playerGoldProvider.Gold);
            _playerGoldProvider.PlayerGoldChanged += button.OnPlayerGoldChange;
            button.SelectTowerButtonClicked += OnSelectTowerButtonClicked;
        }
        _closeBuildMenuButton.Initialize();
        _closeBuildMenuButton.CloseButtonUIClicked += Hide;
        _sellTowerButton.Initialization(sellGoldAmount, canSell);
        _sellTowerButton.SellTowerButtonClicked += OnSellTowerButtonClicked;
    }    

    public void Hide()
    {
        foreach (var button in _selectTowerButtons)
        {
            button.SelectTowerButtonClicked -= OnSelectTowerButtonClicked;
            _playerGoldProvider.PlayerGoldChanged -= button.OnPlayerGoldChange;
            button.Hide();
        }        
        _closeBuildMenuButton.CloseButtonUIClicked -= Hide;
        _closeBuildMenuButton.Hide();
        _sellTowerButton.SellTowerButtonClicked-= OnSellTowerButtonClicked;
        _sellTowerButton.Hide();
        gameObject.SetActive(false); 
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void OnSelectTowerButtonClicked(int buttonIndex) 
    {
        BuildingIndexSelected?.Invoke(buttonIndex);        
    }   
    
    private void OnSellTowerButtonClicked()
    {
        SellTowerButtonClicked?.Invoke();
    }
}
