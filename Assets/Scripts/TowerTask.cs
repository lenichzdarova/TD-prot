using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerTask : MonoBehaviour
{
    private protected AudioSource audioSource;
    [SerializeField] 
    private protected AudioClip audioClip;
    [SerializeField]
    private protected float range;
    [SerializeField]
    private protected float reloadTime;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
    }

    public abstract bool Execute();
    
    // найти цель / itargetprovider/trytofindtarget(bool)    /gettarget(transform)  ///  enemytargetprovider / spawnpointtargetprovider  -
    // в первом случае старый код по поиску врагов, во втором поиск объекта spawnMark

    //передать координаты в модуль движения /imove  move // тут видимо корутина
    //активация
}
