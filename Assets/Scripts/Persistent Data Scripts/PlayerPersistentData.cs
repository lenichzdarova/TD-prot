using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistentData 
{
    public int SceneIndex { get; set; }
    public byte[] UpgradeLevels { get; set; }    

    public PlayerPersistentData()
    {
        //implement default playerdata for new game
        //implement composition from members
    }

    public Dictionary<TowerType,byte> GetUpgradesData()
    {
        var upgrades = new Dictionary<TowerType,byte>();
        string[] towers = Enum.GetNames(typeof(TowerType));

        for(int i =0; i < towers.Length; i++)
        {
            upgrades.Add((Enum.Parse<TowerType>( towers[i])), UpgradeLevels[i]);
        }
        return upgrades;
    }
}
