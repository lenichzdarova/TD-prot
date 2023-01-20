using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Writer
{
   public void WriteData(PlayerPersistentData data, string fileName)
    {
        using (var stream = File.Open(fileName, FileMode.OpenOrCreate))
        {
            using(var writer = new BinaryWriter(stream))
            {
                writer.Write(data.LastPlayedSceneIndex);
                writer.Write(data.UpgradeLevels);
            }
        }
    }
}
