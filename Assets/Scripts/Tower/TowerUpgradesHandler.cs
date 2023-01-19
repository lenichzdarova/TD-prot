

using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradesHandler
{
    private TowerUpgradesDatabase _upgradesDatabase;
    private Dictionary<TowerType, byte> _towerLevels;
    public TowerUpgradesHandler(PlayerPersistentData upgradeLevels)
    {      
        _upgradesDatabase = new TowerUpgradesDatabase(); 
        _towerLevels = upgradeLevels.GetUpgradesData();
    }  
    
    public IEnumerable<TowerUpgrade> GetUpgrades(TowerType towerType)
    {        
        return _upgradesDatabase.GetTowerUpgrades(towerType, _towerLevels[towerType]);
    }
    
}
