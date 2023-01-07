
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyFactory))]

public class Spawner : MonoBehaviour
{
    [SerializeField] WaveSO[] waves;
    [SerializeField] Game controller;
    private EnemyFactory enemyFactory;
    private NavigationPoint navPoint;
    private int waveIndex =0;
    private float nextWaveCountdown=0;
    private float enemyRecycleTime = 2f;
    private float spawnOffsetY=0.1f; 
  
    

    Coroutine nextWaveSpawn;

    private void Update()
    {
        nextWaveCountdown -= Time.deltaTime;        
    }    

    public void Initialize()
    {   
        enemyFactory = GetComponent<EnemyFactory>();
        
        navPoint = GetComponent<NavigationPoint>();              

        nextWaveSpawn = StartCoroutine(WaveSpawnTimer(nextWaveCountdown));        
    }

    private void WaveInitialization()
    {
        WaveSO wave = waves[waveIndex];
        wave.Initialize();
        nextWaveCountdown = wave.NextWaveCountdown();
        SpawnEnemy(wave);
        waveIndex++;  
        if(waveIndex<waves.Length) 
        {
            nextWaveSpawn = StartCoroutine(WaveSpawnTimer(nextWaveCountdown));
        }           
    }

    public void ManualWaveSpawn()
    {
        StopCoroutine(nextWaveSpawn);
        WaveInitialization();
    }

    private void SpawnEnemy(WaveSO wave)
    {
        Enemy enemyPrefab = wave.GetPrefab();
        if (enemyPrefab == null)
        {
            return;
        }
        Enemy enemy = enemyFactory.GetEnemy(enemyPrefab);

        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y + spawnOffsetY, transform.position.z);
        enemy.transform.position = startPosition;
        enemy.Initialize(navPoint);       
        StartCoroutine(SpawnEnemyTimer(wave));
    }

    private IEnumerator SpawnEnemyTimer(WaveSO wave)
    {        
        yield return new WaitForSeconds(wave.GetSpawnTime());
        SpawnEnemy(wave);
    }
    
    private IEnumerator WaveSpawnTimer(float timeToNextWave)
    {              
        yield return new WaitForSeconds(timeToNextWave);
        WaveInitialization();
    }

    private IEnumerator DeletingEnemy(Enemy enemy)
    {
        yield return new WaitForSeconds(enemyRecycleTime);
        Destroy(enemy.gameObject);
    }
      
}
