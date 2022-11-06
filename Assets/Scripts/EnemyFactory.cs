using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class EnemyFactory : ScriptableObject
{
    [SerializeField] Enemy[] enemyPrefab;
    [SerializeField] float[] spawnTime;
    [SerializeField] float[] nextWaveTimer;
    public Dictionary<int, Enemy> enemyMap;


    public Enemy Get(int index)
    {
        return Instantiate(enemyPrefab[index]);
    }

}
