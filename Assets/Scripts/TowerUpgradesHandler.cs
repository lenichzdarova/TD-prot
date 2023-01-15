

using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradesHandler
{    
    public TowerUpgradesHandler()
    {      
      
    }  
    
    public static IEnumerable<TowerUpgrade> GetUpgradeLevel(TowerType towerType)
    {
        var upgradesDatabase = Resources.Load<TowerUpgradesDatabase>("");
        return upgradesDatabase.GetTowerUpgrades(towerType,0);
    }
    
}
