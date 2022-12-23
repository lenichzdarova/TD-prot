using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : IPlayerHealthProvider, IPlayerGoldProvider 
{
    public event Action<int> PlayerGoldChange;
    public event Action<int> PlayerHealthChange;
    
    public string PlayerName { get; private set; }
    public int Health { get; set; }
    public int Gold { get; set ; }
    
    public Player( int health, int gold )
    {        
        Health = health;
        Gold = gold;
    }

    public Player(string name, int health, int gold) : this (health, gold)
    {
        PlayerName = name;         
    } 

    public void SetName(string name)
    {
        PlayerName = name;
    }    

    public void AddGold(int value)
    {
        Gold += value;
        PlayerGoldChange?.Invoke(Gold);
    }

    public void AddHealth(int value)
    {
        Health += value;
        PlayerHealthChange?.Invoke(Health);
    }
}
