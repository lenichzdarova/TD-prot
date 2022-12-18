using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStats : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public float armorPiercing;
    public float slowStrength;
    public int heal;

    public int GetDamage()
    {
        return Random.Range(minDamage, maxDamage+1);
    }
}
