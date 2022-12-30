
using System;
using UnityEngine;

public class TowerStats
{    
    private IAttackStatsProvider _attackStatsProvider;         
    private float _range;   
    private float _reloadTime;

    public TowerStats(TowerType towerType)
    {
        _attackStatsProvider = new TowerAttackStats(towerType);
        switch (towerType)
        {
            case TowerType.BombardT1:
                {
                    _range = 0;
                    _reloadTime = 0;
                    break;
                };
            case TowerType.TinyMageT1:
                {
                    _range = 0;
                    _reloadTime = 0;
                    break;
                };
            case TowerType.TinyMageT2:
                {
                    _range = 0;
                    _reloadTime = 0;
                    break;
                };
            case TowerType.TinyMageT3:
                {
                    _range = 0;
                    _reloadTime = 0;
                    break;
                };
            case TowerType.HobbitT1:
                {
                    _range = 0;
                    _reloadTime = 0;
                    break;
                };
            case TowerType.HobbitT2:
                {
                    _range = 0;
                    _reloadTime = 0;
                    break;
                };
            case TowerType.HobbitT3:
                {
                    _range = 0;
                    _reloadTime = 0;
                    break;
                };
            default:
                {
                    throw new NotImplementedException("Wrong tower type");
                }
        }
    }
    public AttackStats GetAttackStats()
    {
        return _attackStatsProvider.GetAttackStats();
    }
    public float GetRealoadTime()
    {
        return _reloadTime;
    }
    public float GetRange()
    {
        return _range;
    }
}


