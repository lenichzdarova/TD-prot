
using UnityEngine;

public struct AttackStats
{
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public int ArmorPiercing { get; set; }   
    public float Range { get; set; }
    public float AOE { get; set; }
    public float ReloadTime { get; set; }
    public bool Slow { get; set; }

    public int GetDamage()
    {
        return Random.Range(MinDamage, MaxDamage+1);
    }

    public static AttackStats operator + (AttackStats a, AttackStats b)
    {
        return new AttackStats
        {
            MinDamage = a.MinDamage + b.MinDamage,
            MaxDamage = a.MaxDamage + b.MaxDamage,
            ArmorPiercing = a.ArmorPiercing + b.ArmorPiercing,
            Range = a.Range + b.Range,
            AOE = a.AOE + b.AOE,
            ReloadTime = a.ReloadTime + b.ReloadTime,
            Slow = a.Slow == true || b.Slow == true
        };
    }
}
