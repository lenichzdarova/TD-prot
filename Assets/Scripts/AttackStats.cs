using UnityEngine;

public struct AttackStats
{
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public int ArmorPiercing { get; set; }    
    public int Heal { get; set; }
    public float Range { get; set; }
    public float AOE { get; set; }
    public float ReloadTime { get; set; }
    public bool Slow { get; set; }

    public int GetDamage()
    {
        return Random.Range(MinDamage, MaxDamage+1);
    }
}
