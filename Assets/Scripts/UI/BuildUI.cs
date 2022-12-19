using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour, IUIElement
{
    [SerializeField] BuildTowerButton[] buildButtons;       
    [SerializeField] Button sellButton;
    [SerializeField] TextMeshProUGUI sellButtonText;    
    public event Action<int> OnBuild;
    public event Action OnSell;

    public void Initialize(Building[] buildings, int towerCost, bool canSell)
    {
        for (int i = 0; i < buildButtons.Length; i++)
        {
            buildButtons[i].Init(buildings[i]);
        }
        //sell.SetActive(canSell);
    }    

   

    public void SetSellAmount(int amount)
    {
        sellText.text= amount.ToString();
    }
    
    public void GoldChange(int index, bool enoughGold)
    {
        buildButtons[index].interactable= enoughGold;
    }
    

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(false);
    }

    public void Sell()
    {
        OnSell?.Invoke();
        Hide();
    }    
}
