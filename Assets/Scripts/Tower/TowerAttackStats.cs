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
                        SlowStrength = 0,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 3f,
                        AOE = 2,
                        ReloadTime = 2                        
                    };
                };
            case TowerType.TinyMageT1:
                {
                    return new AttackStats()
                    {
                        MinDamage = 0,
                        MaxDamage = 0,
                        SlowStrength = 0,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 0,
                        AOE = 0,
                        ReloadTime = 0
                    };
                };
            case TowerType.TinyMageT2:
                {
                    return new AttackStats()
                    {
                        MinDamage = 0,
                        MaxDamage = 0,
                        SlowStrength = 0,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 0,
                        AOE = 0,
                        ReloadTime = 0
                    };
                };
            case TowerType.TinyMageT3:
                {
                    return new AttackStats()
                    {
                        MinDamage = 0,
                        MaxDamage = 0,
                        SlowStrength = 0,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 0,
                        AOE = 0,
                        ReloadTime = 0
                    };
                };
            case TowerType.HobbitT1:
                {
                    return new AttackStats()
                    {
                        MinDamage = 3,
                        MaxDamage = 6,
                        SlowStrength = 0,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 3f,
                        AOE = 0,
                        ReloadTime = 1
                    };
                };
            case TowerType.HobbitT2:
                {
                    return new AttackStats()
                    {
                        MinDamage = 0,
                        MaxDamage = 0,
                        SlowStrength = 0,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 0,
                        AOE = 0,
                        ReloadTime = 0
                    };
                };
            case TowerType.HobbitT3:
                {
                    return new AttackStats()
                    {
                        MinDamage = 0,
                        MaxDamage = 0,
                        SlowStrength = 0,
                        ArmorPiercing = 0,
                        Heal = 0,
                        Range = 0,
                        AOE = 0,
                        ReloadTime = 0
                    };
                };
            default:
                {
                    throw new NotImplementedException("Wrong tower type");
                }
        }
    }

}
