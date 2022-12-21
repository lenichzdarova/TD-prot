using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{  
    [SerializeField] private TextMeshProUGUI healthValueTextHolder;
    private IPlayerHealthProvider playerHealthProvider;

    public void Init(IPlayerHealthProvider iPlayerHealthProvider)
    {
        Show();
        playerHealthProvider = iPlayerHealthProvider;
        SetHealthText(playerHealthProvider.Health);
        playerHealthProvider.playerHealthChange +=SetHealthText;        
    }  

    private void SetHealthText(int value)
    {
        healthValueTextHolder.text = value.ToString();
    }
    public void Hide()
    {
        playerHealthProvider.playerHealthChange -= SetHealthText;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}