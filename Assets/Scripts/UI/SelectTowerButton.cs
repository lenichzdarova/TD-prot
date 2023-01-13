
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectTowerButton : MonoBehaviour 
{
    public event Action<int> SelectTowerButtonClicked;

    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _towerCostText;
    [SerializeField] Image _image;
    private int _buttonIndex;
    private int _towerCost;

    public void Initialize(Building building, int buttonIndex, int playerGold)
    {
        Show();
        _image.sprite = building.GetIcon();
        _towerCost = building.GetCost();
        _towerCostText.text = _towerCost.ToString();
        this._buttonIndex = buttonIndex;        
        _button.onClick.AddListener(OnButtonClick); 
        _button.interactable = playerGold >= _towerCost? true : false;
    }

    private void OnButtonClick()
    {
        SelectTowerButtonClicked?.Invoke(_buttonIndex);        
    }

    public void Hide()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void OnPlayerGoldChange(int playerGold)
    {
        _button.interactable = playerGold >= _towerCost ? true : false;
    }
}
