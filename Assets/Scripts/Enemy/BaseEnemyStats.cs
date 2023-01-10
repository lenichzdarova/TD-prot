

using System;
using UnityEngine;

public class BaseEnemyStats : IEnemyStatsProvider
{
    private EnemyType _enemyType;

    public BaseEnemyStats(EnemyType enemyType)
    {
        _enemyType = enemyType;
    }

    public EnemyStats GetStats()
    {
        switch (_enemyType)
        {
            case EnemyType.Skeleton:
                {
                    return new EnemyStats
                    {
                        MaxHealth = 20,
                        Damage = 1,
                        Bounty = 1,
                        Armor = 0,
                        Speed = 1
                    };
                }
            default:
                {
                    throw new NotImplementedException($"Enemy {_enemyType} doesn't implemented");
                }
        }
    }
}
