using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPlayerDamage
{
    private const int DEFAULT_GOLD = 100;
    private const int DEFAULT_HEALTH = 100;

    private string name;
    private int hitPoints;
    private int gold;

    public int HitPoints { get { return hitPoints; } }
    public int Gold { get { return gold; } }
    
    public Player( int hitPoints = DEFAULT_HEALTH, int gold = DEFAULT_GOLD)
    {        
        this.hitPoints = hitPoints;
        this.gold = gold;
    }

    public Player(string name, int hitPoints = 100, int gold = 100) : this (hitPoints, gold)
    {
        this.name = name;        
    } 

    public void SetName(string name)
    {
        this.name = name;
    }
    
    public void ApplyDamage(int value)
    {
        hitPoints -= value;
    }
}
