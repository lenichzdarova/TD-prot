using System;
using System.Collections.Generic;

public class TowerUpgrades
{
    private const int MAX_UPGRADES_LEVEL = 5;
    public readonly TowerType _towerType;
    private List <IStatsProvider<AttackStats>> _statsProvider;

    public TowerUpgrades (TowerType towerType)
    {
        _towerType = towerType;
        _statsProvider = new List<IStatsProvider<AttackStats>>(MAX_UPGRADES_LEVEL); //because of list ompimization LUL

        switch (_towerType)
        {
            //create all upgrades decorators for each tower;
        }
    }

    public IStatsProvider<AttackStats>[] GetUpgrades(int upgradesLevel)
    {
        var upgrades = new IStatsProvider<AttackStats>[upgradesLevel];
        for (int i = 0; i < upgradesLevel; i++)
        {
            upgrades[i] = _statsProvider[i];
        }        
        return upgrades;
    }
}
