using System;
using System.Collections.Generic;

public class TowerUpgrades : TowerAttackStatsDecorator
{
    private IEnumerable<string> _upgradeNames;

    public TowerUpgrades (IStatsProvider<AttackStats> statsProvider, IEnumerable<string> upgradeNames) : base (statsProvider)
    {
         _upgradeNames = upgradeNames;
        //we have static database. take stats from it
    }    

    public override AttackStats GetStats()
    {
        return new AttackStats();
    }    
}
