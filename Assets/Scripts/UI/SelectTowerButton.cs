
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectTowerButton : MonoBehaviour 
{
    public event Action<int> SelectTowerButtonClicked;

    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI towerCostText;
    [SerializeField] Image image;
    private int buttonIndex;
    private int towerCost;

    public void Initialize(Building building, int buttonIndex, int playerGold)
    {
        Show();
        image.sprite = building.GetIcon();
        towerCost = building.GetCost();
        towerCostText.text = towerCost.ToString();
        this.buttonIndex = buttonIndex;        
        button.onClick.AddListener(OnButtonClick); 
        button.interactable = playerGold >= towerCost? true : false;
    }

    private void OnButtonClick()
    {
        SelectTowerButtonClicked?.Invoke(buttonIndex);        
    }

    public void Hide()
    {
        button.onClick.RemoveListener(OnButtonClick);
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void OnPlayerGoldChange(int playerGold)
    {
        button.interactable = playerGold >= towerCost ? true : false;
    }
}
