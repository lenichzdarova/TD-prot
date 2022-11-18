using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour
{
    [SerializeField] Button[] buildButtons;
    [SerializeField] TextMeshProUGUI[] prices;
    [SerializeField] Controller controller;
    [SerializeField] Button sell;
    public event Action<int> OnBuild;
    public event Action OnSell;

    public void Initialize(bool canSell)
    {        
        sell.interactable = canSell;
    }

    private void OnDisable()
    {
        foreach(Button button in buildButtons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }        
    }

    public void ActivateButton(int index,Sprite icon, int cost, bool enoughGold)
    {
        Button button = buildButtons[index];
        button.gameObject.SetActive(true);
        button.interactable = enoughGold;        
        button.onClick.AddListener(() =>
        {
            OnBuild?.Invoke(index);
            Close();
        });    
               
        Image image = GetComponent<Image>();
        image.sprite = icon;
        prices[index].text= cost.ToString();
    }    

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Sell()
    {
        //код на продажу
        Close();
    }   
}
