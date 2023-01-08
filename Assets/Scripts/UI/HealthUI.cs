using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{  
    [SerializeField] private TextMeshProUGUI healthValueTextHolder;
    private Health _playerHealth;

    public void Initialize(Health playerHealth)
    {
        Show();
        _playerHealth = playerHealth;
        SetHealthText(_playerHealth.GetHealth());
        _playerHealth.HealthChanged += SetHealthText;        
    }  

    private void SetHealthText(int value)
    {
        healthValueTextHolder.text = value.ToString();
    }
    public void Hide()
    {
        _playerHealth.HealthChanged -= SetHealthText;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}