using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public Enemy GetEnemy(Enemy prefab)
    {
        Enemy enemy = Instantiate(prefab);
        enemy.AskForRecycle += Recycle;

        return enemy;
    }

    public void Recycle(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }    
}
