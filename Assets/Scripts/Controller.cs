using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    private int round;
    private float baseDelay=5;

    private void OnEnable()
    {        
        NewRound();
    }

    private IEnumerator ActivationDelay(float delay)
    {        
        Debug.Log("Round starting");
        yield return new WaitForSeconds(delay);
        spawner.SpawnWave(round, NewRound);
    }

    public void NewRound()
    {
        ++round;
        StartCoroutine(ActivationDelay(baseDelay));
    }    

}
