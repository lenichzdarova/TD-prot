using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : IPlayerDamage, IPlayerEventsProvider
{
    public event Action<int> playerGoldChange;
    public event Action<int> playerHealthChange;    

    private string name;
    private int health;
    private int gold;

    public int Health { get { return health; } }
    public int Gold { get { return gold; } }
    
    public Player( int health, int gold )
    {        
        this.health = health;
        this.gold = gold;
    }

    public Player(string name, int health, int gold) : this (health, gold)
    {
        this.name = name;        
    } 

    public void SetName(string name)
    {
        this.name = name;
    }
    
    public void ApplyDamage(int value)
    {
        health -= value;
    }

    public void AddGold(int value)
    {
        gold += value;
        playerGoldChange?.Invoke(Gold);
    }

    public void AddHealth(int value)
    {
        health += value;
        playerHealthChange?.Invoke(Gold);
    }
}
