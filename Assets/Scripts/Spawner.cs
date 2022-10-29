using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<GameObject> enemyList;
    private int enemyIndex;

    public void SpawnWave(int round, Action callback)
    {
        WaveSO wave = Resources.Load<WaveSO>($"ScriptableObjects/Wave/{round}");
        enemyList= wave.GetEnemyList();       
        
        StartCoroutine(SpawnEnemy(enemyList[enemyIndex++]));
        //callback(); //here must be victory condition check class which will call callback
    }

    private IEnumerator SpawnEnemy(GameObject enemyPrefab)
    {
        yield return new WaitForSeconds(1);               
        GameObject enemyGO = Instantiate(enemyPrefab, transform.position, new Quaternion(1,1,1,1));
        if (enemyIndex < enemyList.Count)
        {
            StartCoroutine(SpawnEnemy(enemyList[enemyIndex++]));
        }
    }
}
