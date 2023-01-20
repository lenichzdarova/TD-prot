using System;
using System.IO;


public class Reader 
{
    public PlayerPersistentData ReadData(string fileName)
    {
        using (var stream = File.OpenRead(fileName))
        {
            using (var reader = new BinaryReader(stream))
            {
                var data = new PlayerPersistentData();
                data.LastPlayedSceneIndex = reader.ReadInt32();
                for (int i = 0; i < data.UpgradeLevels.Length; i++)
                {
                    data.UpgradeLevels[i] = reader.ReadByte();
                }
                return data;
            }
        }
    }
}
