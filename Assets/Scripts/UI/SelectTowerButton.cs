
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectTowerButton : MonoBehaviour 
{
    public event Action<int> SelectTowerButtonClicked;

    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI towerCost;
    [SerializeField] Image image;
    private int buttonIndex;

    public void Init(Building building, int buttonIndex)
    {
        Show();
        image.sprite = building.GetIcon();
        towerCost.text = building.GetCost().ToString();
        this.buttonIndex = buttonIndex;        
        button.onClick.AddListener(OnButtonClick);               
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
}
