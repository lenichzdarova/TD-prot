using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemySO",menuName ="Scriptable Objects/Enemy", order = 0) ]

public class EnemySO : ScriptableObject
{
    [SerializeField] int maxHitPoints;
    [SerializeField] float speed;
    [SerializeField] GameObject prefab;
}
