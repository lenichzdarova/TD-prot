using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class TowerUpgradesStatsProvider : TowerAttackStatsDecorator
{
    private TowerType _towerType;
    private IEnumerable<TowerUpgrade> _upgrades;

    public TowerUpgradesStatsProvider (IStatsProvider<AttackStats> statsProvider, TowerType towerType) : base (statsProvider)
    {
        _towerType = towerType;
        _upgrades = TowerUpgradesHandler.GetUpgradeLevel(towerType);        
    }    

    public override AttackStats GetStats()
    {
        var stats = _statsProvider.GetStats();
        foreach (var upgrade in _upgrades)
        {
            stats += upgrade.GetStats();
        }

        return stats;
    }    
}
