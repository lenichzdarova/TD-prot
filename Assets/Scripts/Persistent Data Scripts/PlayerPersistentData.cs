using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistentData 
{
    
    public int LastPlayedSceneIndex { get; set; }
    public byte[] UpgradeLevels { get; set; }    

    public PlayerPersistentData()
    {
        LastPlayedSceneIndex = 0;
        int towerTypeNumber = Enum.GetNames(typeof(TowerType)).Length;
        UpgradeLevels = new byte[towerTypeNumber];
        Array.Fill(UpgradeLevels, (byte)0);        
    }

    public void SetUpgradesData(Dictionary<TowerType,byte> towerUpgradesLevel)
    {
        int index = 0;
        foreach(var value in towerUpgradesLevel.Values) 
        {
            UpgradeLevels[index] = value;
            index++;
        }
    }

    public Dictionary<TowerType,byte> GetUpgradesData()
    {
        var upgrades = new Dictionary<TowerType,byte>();
        string[] towers = Enum.GetNames(typeof(TowerType));

        for(int i = 0; i < towers.Length; i++)
        {
            upgrades.Add((Enum.Parse<TowerType>( towers[i])), UpgradeLevels[i]);
        }
        return upgrades;
    }
}
