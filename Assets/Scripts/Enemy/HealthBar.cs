using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _fill;
    [SerializeField] Slider _slider;    
    public Gradient _gradient;
   
    public void Initialize(int maxHealth)
    {        
        _slider.maxValue= maxHealth;
        _slider.value = maxHealth;

       _fill.color = _gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        _slider.value = health;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }    
}
