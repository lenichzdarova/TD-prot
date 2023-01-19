using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class DataManager 
{
    private const string DATA_FILE_NAME = "PlayerData.bat";    

    public void SaveData(PlayerPersistentData data)
    {
        var writer = new Writer();
        writer.WriteData(data,DATA_FILE_NAME);
    }
    public PlayerPersistentData LoadData()
    {
        if (File.Exists(DATA_FILE_NAME))
        {
            var reader = new Reader();
            return reader.ReadData(DATA_FILE_NAME);
        }

        var playerDefaultData = new PlayerPersistentData();
        SaveData(playerDefaultData);
        return playerDefaultData;                
    }  
    

}
