using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSo",menuName = "Scriptable Objects/Wave", order = 0)]

public class WaveSO : ScriptableObject
{
    [SerializeField] List<ENEMY_NAMES> enemyList;
    
    [SerializeField] float spawnTime;
}
