using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
    private Reader _reader;
    private Writer _writer;

    private const string DATA_FILE_NAME = "PlayerData.bat";

    public DataManager()
    {
        _reader = new Reader();
        _writer = new Writer();
    }

    public void SaveData(PlayerPersistantData data)
    {
        _writer.WriteData(data,DATA_FILE_NAME);
    }
    public PlayerPersistantData LoadData()
    {
        return _reader.ReadData(DATA_FILE_NAME);
    }
}
