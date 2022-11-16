using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour
{
    [SerializeField] Button[] buildButtons;
    [SerializeField] TextMeshProUGUI[] prices;
    [SerializeField] Controller controller;
    public event Action<int> OnBuild;


    private void OnDisable()
    {
        foreach(Button button in buildButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void ActivateButtons(int count)
    {
        for(int i =0; i < count; i++)
        {
            buildButtons[i].gameObject.SetActive(true);
        }
    }

    public void SetButtonIcons(Sprite[] sprites)
    {
        for(int i =0;i<sprites.Length;i++)
        {
            Image image = buildButtons[i].GetComponent<Image>();
            image.sprite = sprites[i];
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
