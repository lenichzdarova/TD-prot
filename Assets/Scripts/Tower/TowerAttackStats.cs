using System;

public class TowerAttackStats : IAttackStatsProvider
{
    private readonly TowerType _towerType;

    public TowerAttackStats (TowerType towerType)
    {
        _towerType = towerType;
    }

    public AttackStats GetAttackStats()
    {
        switch(_towerType)
        {
            case TowerType.BombardT1:
                {
                    return new AttackStats()
                    {
                        MinDamage = 5,
                        MaxDamage = 10,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 3f,
                        AOE = 2f,
                        ReloadTime = 2f,
                        Slow = false
                    };
                };
            case TowerType.TinyMageT1:
                {
                    return new AttackStats()
                    {
                        MinDamage = 5,
                        MaxDamage = 10,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 3f,
                        AOE = 2f,
                        ReloadTime = 2f,
                        Slow = false
                    };
                };
            case TowerType.TinyMageT2:
                {
                    return new AttackStats()
                    {
                        MinDamage = 5,
                        MaxDamage = 10,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 3f,
                        AOE = 2f,
                        ReloadTime = 2f,
                        Slow = false
                    };
                };
            case TowerType.TinyMageT3:
                {
                    return new AttackStats()
                    {
                        MinDamage = 5,
                        MaxDamage = 10,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 3f,
                        AOE = 2f,
                        ReloadTime = 2f,
                        Slow = false
                    };
                };
            case TowerType.HobbitT1:
                {
                    return new AttackStats()
                    {
                        MinDamage = 5,
                        MaxDamage = 10,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 3f,
                        AOE = 2f,
                        ReloadTime = 2f,
                        Slow = false
                    };
                };
            case TowerType.HobbitT2:
                {
                    return new AttackStats()
                    {
                        MinDamage = 5,
                        MaxDamage = 10,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 3f,
                        AOE = 2f,
                        ReloadTime = 2f,
                        Slow = false
                    };
                };
            case TowerType.HobbitT3:
                {
                    return new AttackStats()
                    {
                        MinDamage = 5,
                        MaxDamage = 10,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 3f,
                        AOE = 2f,
                        ReloadTime = 2f,
                        Slow = false
                    };
                };
            default:
                {
                    throw new NotImplementedException($"Tower type {_towerType} doesn't implemented");
                }
        }
    }

}
