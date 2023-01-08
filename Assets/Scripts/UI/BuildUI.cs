using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour
{
    public event Action<int> BuildingIndexSelected;
    public event Action SellTowerButtonClicked;

    [SerializeField] SelectTowerButton[] selectTowerButtons;       
    [SerializeField] SellTowerButton sellTowerButton;    
    [SerializeField] CloseButtonUI closeBuildMenuButton;
    private IPlayerGoldProvider playerGoldProvider;

    public void Initialize(IPlayerGoldProvider iplayerGoldProvider, Building[] buildings, int sellGoldAmount, bool canSell)
    {
        Show();
        playerGoldProvider = iplayerGoldProvider;
        for (int i = 0; i < buildings.Length; i++)
        {
            SelectTowerButton button = selectTowerButtons[i];
            button.Initialize(buildings[i],i,playerGoldProvider.Gold);
            playerGoldProvider.PlayerGoldChanged += button.OnPlayerGoldChange;
            button.SelectTowerButtonClicked += OnSelectTowerButtonClicked;
        }
        closeBuildMenuButton.Initialize();
        closeBuildMenuButton.CloseButtonUIClicked += Hide;
        sellTowerButton.Initialization(sellGoldAmount, canSell);
        sellTowerButton.SellTowerButtonClicked += OnSellTowerButtonClicked;
    }    

    public void Hide()
    {
        foreach (var button in selectTowerButtons)
        {
            button.SelectTowerButtonClicked -= OnSelectTowerButtonClicked;
            playerGoldProvider.PlayerGoldChanged -= button.OnPlayerGoldChange;
            button.Hide();
        }        
        closeBuildMenuButton.CloseButtonUIClicked -= Hide;
        closeBuildMenuButton.Hide();
        sellTowerButton.SellTowerButtonClicked-= OnSellTowerButtonClicked;
        sellTowerButton.Hide();
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
