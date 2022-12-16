using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats 
{
    private int hitPoints;
    private int gold;

    public int HitPoints { get { return hitPoints; } }
    public int Gold { get { return gold; } }


    public PlayerStats(int hitPoints, int gold)
    {
        this.hitPoints = hitPoints;
        this.gold = gold;
    }    
}
