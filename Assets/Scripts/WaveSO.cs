using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSo",menuName = "Scriptable Objects/Wave", order = 0)]

public class WaveSO : ScriptableObject
{
    [SerializeField] EnemySO[] enemyList;
    [SerializeField] int enemyCount;
    [SerializeField] float spawnTime;
}
