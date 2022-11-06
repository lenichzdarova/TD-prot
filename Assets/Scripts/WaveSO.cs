using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSo",menuName = "Scriptable Objects/Wave", order = 0)]

public class WaveSO : ScriptableObject
{
    [SerializeField] Enemy[] enemyPrefabs;
    
    [SerializeField] float[] spawnTime;
    [SerializeField] int[] countToSpawn;
    
   public float[] GetSpawnTime()
    {
        return spawnTime;
    }   

    public Enemy GetEnemy(int index)
    {
        return Instantiate(enemyPrefabs[index]);
    }    

    public int GetCount(int enemyIndex)
    {
        return countToSpawn[enemyIndex];
    }
}
