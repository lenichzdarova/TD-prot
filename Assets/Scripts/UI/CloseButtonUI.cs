using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButtonUI : MonoBehaviour
{
    public event Action CloseButtonUIClicked;

    [SerializeField] private Button button;

    public void Initialize()
    {
        Show();
        button.onClick.AddListener(OnButtonClick);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        button.onClick.RemoveListener(OnButtonClick);
        gameObject.SetActive(false);
    }

    private void OnButtonClick()
    {
        CloseButtonUIClicked?.Invoke();
    }
}
