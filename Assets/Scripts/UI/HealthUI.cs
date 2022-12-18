using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour, IUIElement
{  
    [SerializeField] private TextMeshProUGUI healthValueHolder;
    public void Init(IPlayerEventsProvider playerEventsProvider, int playerHealth)
    { 
        SetHealthValue(playerHealth);
        playerEventsProvider.playerGoldChange +=SetHealthValue;
        //Hide();
    }  

    private void SetHealthValue(int value)
    {
        healthValueHolder.text = value.ToString();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(false);
    }
}