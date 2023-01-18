using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Writer
{
   public void WriteData(PlayerPersistantData data, string fileName)
    {
        using (var stream = File.Open(fileName, FileMode.OpenOrCreate))
        {
            using(var writer = new BinaryWriter(stream))
            {
                //parse data;
            }
        }
    }
}
