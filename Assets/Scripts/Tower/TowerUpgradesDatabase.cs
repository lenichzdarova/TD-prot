
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerUpgradesDatabase 
{
    [SerializeField]
    private TowerUpgrade[] _allUpgrades;

    public TowerUpgradesDatabase()
    {
        _allUpgrades = Resources.LoadAll<TowerUpgrade>("ScriptableObjects/TowerUpgrades");
    }

    public IEnumerable<TowerUpgrade> GetTowerUpgrades(TowerType towerType,byte currentLevel)
    {
        var upgrades = from upgrade in _allUpgrades
                       where upgrade.GetTowerType() == towerType &&  upgrade.GetUpgradeLevel() <= currentLevel
                       select upgrade;

        return upgrades;
    }
}
