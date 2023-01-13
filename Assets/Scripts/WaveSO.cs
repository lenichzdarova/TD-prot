using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSo",menuName = "Scriptable Objects/Wave", order = 0)]

[Serializable]
public class WaveSO : ScriptableObject
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] float _nextWaveCountdown;
    [SerializeField] float _spawnTime;
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
        return _enemyPrefab;        
    }    

    public float GetSpawnTime()
    {
        return _spawnTime;
    }

    public int GetCountToSpawn()
    {
        return countToSpawn;
    }    

    public float NextWaveCountdown()
    {
        return _nextWaveCountdown;
    }
}
