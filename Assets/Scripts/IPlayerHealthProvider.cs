using System;
using System.Collections;
using UnityEngine;

public interface IPlayerHealthProvider
{
    public event Action<int> PlayerHealthChange;

    public int Health { get; set; }    
    
    public void AddHealth(int value);        
}
