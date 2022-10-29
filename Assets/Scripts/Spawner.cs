using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<Enemy> enemyList;    

    public void Spawn(int round, Action callback)
    {
        callback(); //here must be victory condition check class which will call callback
    }

}
