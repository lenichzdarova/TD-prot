
using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] WaveSO[] waves;
    [SerializeField] Controller controller;
    private NavigationPoint navPoint;
    private int waveIndex =0;
    private float nextWaveCountdown=0;
    private float enemyRecycleTime = 2f;
    private float spawnOffsetY=0.1f;
    private float distanceToLastNavPoint=0f;

    Coroutine nextWaveSpawn;

    private void Update()
    {
        nextWaveCountdown -= Time.deltaTime;        
    }    

    public void Initialize()
    {        
        navPoint = GetComponent<NavigationPoint>();

        NavigationPoint tempNavPoint = navPoint;
        while(tempNavPoint != tempNavPoint.GetNextNavigationPoint())
        {
            Vector3 APoint = tempNavPoint.GetDestination();
            Vector3 BPoint = tempNavPoint.GetNextNavigationPoint().GetDestination();
            float distance = Vector3.Distance(APoint,BPoint);
            distanceToLastNavPoint += distance;
            tempNavPoint= tempNavPoint.GetNextNavigationPoint();
        }

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
        Enemy enemy = wave.GetEnemy();
        if (enemy == null)
        {
            return;
        }
        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y + spawnOffsetY, transform.position.z);
        enemy.transform.position = startPosition;
        enemy.SetPath(navPoint);
        enemy.SetDistance(distanceToLastNavPoint);
        enemy.SetSpawner(this);
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
    
    public void Recycle(Enemy enemy)
    {
        controller.ChangeGold(enemy.GetGold());
        StartCoroutine(DeletingEnemy(enemy));
    }

    private IEnumerator DeletingEnemy(Enemy enemy)
    {
        yield return new WaitForSeconds(enemyRecycleTime);
        Destroy(enemy.gameObject);
    }
      
}
