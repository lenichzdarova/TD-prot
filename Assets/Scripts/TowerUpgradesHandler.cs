

using System;
using System.Collections.Generic;

public class TowerUpgradesHandler
{
    private static Dictionary<TowerType, int> _upgradesLevel; 
    private static List<TowerUpgrades> _upgrades;

    public TowerUpgradesHandler()
    {
        int baseUpgradesLevel = 0;
        _upgradesLevel = new Dictionary<TowerType, int>();
        _upgrades= new List<TowerUpgrades>();
        foreach (var value in Enum.GetValues(typeof(TowerType)))
        {
            TowerType towerType = (TowerType)value;
            _upgrades.Add(new TowerUpgrades(towerType));
            _upgradesLevel.Add(towerType, baseUpgradesLevel);
        }       
    }

    public void SetUpgradesLevel(TowerType towerType, int level)
    {
        _upgradesLevel[towerType] = level;
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
