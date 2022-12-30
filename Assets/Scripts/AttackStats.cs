using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AttackStats
{
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public float ArmorPiercing { get; set; }
    public float SlowStrength { get; set; }
    public int Heal { get; set; }
    public float Range { get; set; }
    public float AOE { get; set; }
    public float ReloadTime { get; set; }

    public int GetDamage()
    {
        return Random.Range(MinDamage, MaxDamage+1);
    }
}
