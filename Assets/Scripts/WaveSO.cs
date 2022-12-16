using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSo",menuName = "Scriptable Objects/Wave", order = 0)]

[Serializable]
public class WaveSO : ScriptableObject
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] float nextWaveCountdown;
    [SerializeField] float spawnTime;
    [SerializeField] int countToSpawn;
    //[SerializeField] float HPModifier=1;

    private int alreadySpawned;

    public void Initialize()
    {
        alreadySpawned = 0;
    }

    public Enemy GetPrefab()
    {   
        if(alreadySpawned == countToSpawn)
        {
            return null;
        }
        alreadySpawned++;        
        return enemyPrefab;        
    }    

    public float GetSpawnTime()
    {
        return spawnTime;
    }

    public int GetCountToSpawn()
    {
        return countToSpawn;
    }    

    public float NextWaveCountdown()
    {
        return nextWaveCountdown;
    }
}
