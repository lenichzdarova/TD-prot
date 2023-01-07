using System;
using UnityEngine;

public struct EnemyInitialStats
{
    public readonly int _maxHealth, _damage, _bounty, _armor;
    public readonly float _speed;

    public EnemyInitialStats(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Skeleton:
                {
                    _maxHealth = 20;
                    _damage = 1;
                    _bounty = 1;
                    _armor = 0;
                    _speed = 1;
                    break;
                }
            default:
                {
                    _maxHealth=0;
                    _damage = 0;
                    _bounty = 0;
                    _armor = 0;
                    _speed = 0;
                    break;
                }
        }
    }
}
