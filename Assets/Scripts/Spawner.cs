using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<ENEMY_NAMES> enemyList;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(ENEMY_NAMES.Sphere));//тест
    }

    public void SpawnWave(int round, Action callback)
    {
        callback(); //here must be victory condition check class which will call callback
    }

    private IEnumerator SpawnEnemy(ENEMY_NAMES enemyName)
    {
        yield return new WaitForSeconds(1);
        EnemySO enemySO = Resources.Load<EnemySO>($"ScriptableObjects/Enemy/{enemyName}");        
        GameObject enemyPrefab = enemySO.GetPrefab();         
        GameObject enemyGO = Instantiate(enemyPrefab, transform.position, new Quaternion(1,1,1,1)); // разобраться с квартернионом
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.SetSpeed(enemySO.GetSpeed());
        enemy.SetHP(enemySO.GetMaxHitPoints());
    }




}
