
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerUpgradesDatabase : ScriptableObject
{
    [SerializeField]
    private List<TowerUpgrade> _allUpgrades;

    public IEnumerable<TowerUpgrade> GetTowerUpgrades(TowerType towerType,int currentLevel)
    {
        var upgrades = from upgrade in _allUpgrades
                       where upgrade.GetTowerType() == towerType &&  upgrade.GetUpgradeLevel() <= currentLevel
                       select upgrade;

        return upgrades;
    }

}
