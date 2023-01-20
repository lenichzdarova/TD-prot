using System.IO;


public static class DataManager 
{
    private const string DATA_FILE_NAME = "PlayerData.bat";    

    public static void SaveData(PlayerPersistentData data)
    {
        var writer = new Writer();
        writer.WriteData(data,DATA_FILE_NAME);
    }
    public static PlayerPersistentData LoadData()
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
