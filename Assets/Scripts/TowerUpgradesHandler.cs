

using System;
using System.Collections.Generic;

public class TowerUpgradesHandler
{
    private static Dictionary<TowerType, int> _upgradesLevel;
    private static List<TowerUpgrades> _upgrades;

    public TowerUpgradesHandler()
    {
        //cycle towerTypes to inialize all upgrades;
    }

    public static IStatsProvider<AttackStats>[] GetUpgrades(TowerType towerType)
    {     
        foreach (var upgrade in _upgrades)
        {
            int upgradesLevel = _upgradesLevel[towerType];            
            if (upgrade._towerType == towerType)
            {
                return upgrade.GetUpgrades(upgradesLevel);
            }
        }
        throw new NotImplementedException($"Tower type {towerType} upgrades not implemented");
    }
}
