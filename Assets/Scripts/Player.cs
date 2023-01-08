using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : IPlayerGoldProvider 
{
    public event Action<int> PlayerGoldChanged;    
    
    public string PlayerName { get; private set; }   
    public int Gold { get; set ; }

    private Health _health;
    public Health GetHealth() { return _health; }
    
    public Player( int health, int gold )
    {       
        Gold = gold;
        _health = new Health(health);
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
        PlayerGoldChanged?.Invoke(Gold);
    }

    public void RemoveGold(int value)
    {
        Gold -= value;
        PlayerGoldChanged?.Invoke(Gold);
    }    
}
