using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour
{
    public event Action<int> buildingIndexSelected;

    [SerializeField] SelectTowerButton[] selectTowerButtons;       
    [SerializeField] Button sellButton;
    [SerializeField] TextMeshProUGUI sellButtonText;
    [SerializeField] Button closeBuildMenuButton;    

    public void Initialize(Building[] buildings, int towerCost, bool canSell)
    {
        Show();
        for (int i = 0; i < buildings.Length; i++)
        {
            selectTowerButtons[i].Init(buildings[i],i);
            selectTowerButtons[i].SelectTowerButtonClicked += OnSelectTowerButtonClicked;
        }
        closeBuildMenuButton.onClick.AddListener(Hide);
    }    

    public void Hide()
    {
        foreach (var button in selectTowerButtons)
        {
            button.SelectTowerButtonClicked -= OnSelectTowerButtonClicked;
            button.Hide();
        }
        closeBuildMenuButton.onClick.RemoveListener(Hide);
        gameObject.SetActive(false); 
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void OnSelectTowerButtonClicked(int buttonIndex) 
    {
        buildingIndexSelected?.Invoke(buttonIndex);        
    }     
}
