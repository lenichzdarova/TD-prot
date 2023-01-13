using System;
using System.Collections.Generic;

public class TowerUpgrades
{
    public readonly TowerType _towerType;
    private List <IStatsProvider<AttackStats>> _statsProvider;

    public TowerUpgrades (TowerType towerType)
    {
        _towerType = towerType;
        _statsProvider = new List<IStatsProvider<AttackStats>>(5); //because of list ompimization LUL

        switch (_towerType)
        {
            //create all upgrades decorators for each tower;
        }
    }

    public IStatsProvider<AttackStats>[] GetUpgrades(int upgradesLevel)
    {        
        var upgrades = new IStatsProvider<AttackStats>[upgradesLevel];
        _statsProvider.CopyTo(0, upgrades, 0, upgradesLevel);
        return upgrades;
    }
}
