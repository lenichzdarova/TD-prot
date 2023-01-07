using System;

public class Health 
{
    public event Action Death;
    public event Action<int> HealthChanged;

    private int _maxHealth;
    private int _currentHealth;

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public void ChangeHealth(int value)
    {
        _currentHealth += value;
        if (_currentHealth > _maxHealth) 
        {
            _currentHealth = _maxHealth;
        }
        HealthChanged?.Invoke(_currentHealth);
          
        if (_currentHealth <= 0)
        {
            Death?.Invoke();
        }
    }
}
