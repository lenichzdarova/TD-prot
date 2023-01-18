using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Reader 
{
    public PlayerPersistantData ReadData(string fileName)
    {
        if (File.Exists(fileName))
        {
            using (var stream = File.OpenRead(fileName))
            {
                using(var reader = new StreamReader(stream))
                {
                    return new PlayerPersistantData
                    {
                       //parse stream to playerData
                    };
                }
            }
        }        

        return new PlayerPersistantData();
    }
}
