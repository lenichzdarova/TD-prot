using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<GameObject> enemyList;
    private int enemyIndex;
    private float spawnTime=1;
    private NavigationPoint navPoint;

    private void Awake()
    {        
        navPoint = GetComponent<NavigationPoint>();        
        SpawnWave(1);
    }

    public void SpawnWave(int round)
    {
        enemyIndex = 0;
        WaveSO wave = Resources.Load<WaveSO>($"ScriptableObjects/Wave/{round}");
        enemyList= wave.GetEnemyList();       
        
        StartCoroutine(SpawnEnemy(enemyList[enemyIndex++]));        
    }

    private IEnumerator SpawnEnemy(GameObject enemyPrefab)
    {
        yield return new WaitForSeconds(spawnTime);               
        GameObject enemyGO = Instantiate(enemyPrefab, transform.position, new Quaternion(1,1,1,1));        
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.SetPath(navPoint);
        if (enemyIndex < enemyList.Count)
        {
            StartCoroutine(SpawnEnemy(enemyList[enemyIndex++]));
        }
    }
}
