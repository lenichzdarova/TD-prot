using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SellTowerButton : MonoBehaviour
{
    public event Action SellTowerButtonClicked;

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _sellGoldAmountText;

    public void Initialization(int sellGoldAmount, bool canSell)
    {
        if(canSell)
        {
            Show();
            _sellGoldAmountText.text = sellGoldAmount.ToString();
            _button.onClick.AddListener(OnButtonClicked);
        }
    }

    private void OnButtonClicked()
    {
        SellTowerButtonClicked?.Invoke();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
        gameObject.SetActive(false);
    }
}
