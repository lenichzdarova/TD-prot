
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json.Schema;

public class TowerUpgradesDatabase 
{
    [SerializeField]
    private TowerUpgrade[] _allUpgrades;

    public TowerUpgradesDatabase()
    {
        _allUpgrades = Resources.LoadAll<TowerUpgrade>("ScriptableObjects/TowerUpgrades");
    }

    public IEnumerable<TowerUpgrade> GetTowerUpgrades(TowerType towerType,int currentLevel)
    {
        var upgrades = from upgrade in _allUpgrades
                       where upgrade.GetTowerType() == towerType &&  upgrade.GetUpgradeLevel() <= currentLevel
                       select upgrade;

        return upgrades;
    }
}
