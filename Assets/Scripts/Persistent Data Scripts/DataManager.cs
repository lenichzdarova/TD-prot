using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var reader = new Reader();
        return reader.ReadData(DATA_FILE_NAME);
    }
}
