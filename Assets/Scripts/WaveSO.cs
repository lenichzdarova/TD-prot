using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSo",menuName = "Scriptable Objects/Wave", order = 0)]

public class WaveSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyList;
    
    [SerializeField] float spawnTime;

    public List<GameObject> GetEnemyList()
    {
        return enemyList;
    }
}
