
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyFactory))]

public class Spawner : MonoBehaviour
{
    [SerializeField] WaveSO[] _waves;
    [SerializeField] SceneLauncher _controller;
    private EnemyFactory _enemyFactory;
    private NavigationPoint _navPoint;
    private int _waveIndex =0;
    private float _nextWaveCountdown=0;
    private float _enemyRecycleTime = 2f;
    private float _spawnOffsetY=0.1f;   

    private Coroutine _nextWaveSpawn;

    private void Update()
    {
        _nextWaveCountdown -= Time.deltaTime;        
    }    

    public void Initialize()
    {   
        _enemyFactory = GetComponent<EnemyFactory>();        
        _navPoint = GetComponent<NavigationPoint>();
        _nextWaveSpawn = StartCoroutine(WaveSpawnTimer(_nextWaveCountdown));        
    }

    private void WaveInitialization()
    {
        WaveSO wave = _waves[_waveIndex];
        wave.Initialize();
        _nextWaveCountdown = wave.NextWaveCountdown();
        SpawnEnemy(wave);
        _waveIndex++;  
        if(_waveIndex<_waves.Length) 
        {
            _nextWaveSpawn = StartCoroutine(WaveSpawnTimer(_nextWaveCountdown));
        }           
    }

    public void ManualWaveSpawn()
    {
        StopCoroutine(_nextWaveSpawn);
        WaveInitialization();
    }

    private void SpawnEnemy(WaveSO wave)
    {
        Enemy enemyPrefab = wave.GetPrefab();
        if (enemyPrefab == null)
        {
            return;
        }
        Enemy enemy = _enemyFactory.GetEnemy(enemyPrefab);
        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y + _spawnOffsetY, transform.position.z);
        enemy.transform.position = startPosition;
        enemy.Initialize(_navPoint);       
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
        yield return new WaitForSeconds(_enemyRecycleTime);
        Destroy(enemy.gameObject);
    }
      
}
