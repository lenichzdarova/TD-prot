using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour, IUIElement
{
    [SerializeField] Button[] buildButtons;
    [SerializeField] TextMeshProUGUI[] prices;
    [SerializeField] Game controller;
    [SerializeField] GameObject sell;
    [SerializeField] TextMeshProUGUI sellText;    
    public event Action<int> OnBuild;
    public event Action OnSell;

    public void Initialize(bool canSell)
    {
        foreach (var button in buildButtons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }
        sell.SetActive(canSell);
    }    

    public void ActivateButton(int index,Sprite icon, int cost, bool enoughGold)
    {
        Button button = buildButtons[index];
        button.gameObject.SetActive(true);
        button.interactable = enoughGold;        
        button.onClick.AddListener(() =>
        {
            OnBuild?.Invoke(index);
            Hide();
        });    
               
        Image image = button.GetComponent<Image>();
        image.sprite = icon;
        prices[index].text= cost.ToString();
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
