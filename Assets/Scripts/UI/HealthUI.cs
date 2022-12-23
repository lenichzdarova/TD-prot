using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{  
    [SerializeField] private TextMeshProUGUI healthValueTextHolder;
    private IPlayerHealthProvider playerHealthProvider;

    public void Initialize(IPlayerHealthProvider iPlayerHealthProvider)
    {
        Show();
        playerHealthProvider = iPlayerHealthProvider;
        SetHealthText(playerHealthProvider.Health);
        playerHealthProvider.PlayerHealthChange +=SetHealthText;        
    }  

    private void SetHealthText(int value)
    {
        healthValueTextHolder.text = value.ToString();
    }
    public void Hide()
    {
        playerHealthProvider.PlayerHealthChange -= SetHealthText;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}