
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] WaveSO[] waves;    
    private NavigationPoint navPoint;
    private int waveNumber =0;

    WaveSO currenWave;
    int[] counter;

    private void Awake()
    {        
        navPoint = GetComponent<NavigationPoint>();
        SpawnWave(waveNumber);
        waveNumber++;
    }

    public void SpawnWave(int waveIndex)
    {        
        currenWave = waves[waveIndex];
        float[] spawnTime = currenWave.GetSpawnTime();
        counter = new int[spawnTime.Length];
        for (int i = 0; i < spawnTime.Length; i++)
        {
            StartCoroutine(SpawnEnemy(spawnTime[i], i));
        }
    }

    private IEnumerator SpawnEnemy(float timeToSpawn,int enemyIndex)
    {
        yield return new WaitForSeconds(timeToSpawn);
        Enemy instance = currenWave.GetEnemy(enemyIndex);
        float MaxOffset = 0.5f;
        Vector3 spawnOfsset = new Vector3(Random.Range(-MaxOffset, MaxOffset),0,0); 
        instance.transform.position = transform.position+spawnOfsset;
        instance.SetPath(navPoint);        
        counter[enemyIndex]++; 
        
        if (counter[enemyIndex] < currenWave.GetCount(enemyIndex))
        {
            StartCoroutine(SpawnEnemy(timeToSpawn, enemyIndex));
        }        
    }    
}
