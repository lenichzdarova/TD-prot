using System;
using System.Collections.Generic;

public class TowerUpgradesStatsProvider : TowerAttackStatsDecorator
{
    private TowerType _towerType;

    public TowerUpgradesStatsProvider (IStatsProvider<AttackStats> statsProvider, TowerType towerType) : base (statsProvider)
    {
         _towerType = towerType;
        //we have static database. take stats from it
    }    

    public override AttackStats GetStats()
    {
        var stats = _statsProvider.GetStats();

        return stats;
    }    
}
