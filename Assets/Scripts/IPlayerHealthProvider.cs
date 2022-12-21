using System;
using System.Collections;
using UnityEngine;

public interface IPlayerHealthProvider
{
    public event Action<int> playerHealthChange;

    public int Health { get; set; }    
    
    public void AddHealth(int value);        
}
