

using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradesHandler
{
    private TowerUpgradesDatabase _upgradesDatabase;
    public TowerUpgradesHandler()
    {      
      _upgradesDatabase= new TowerUpgradesDatabase();
    }  
    
    public IEnumerable<TowerUpgrade> GetUpgradeLevel(TowerType towerType)
    {        
        return _upgradesDatabase.GetTowerUpgrades(towerType,0);
    }
    
}
