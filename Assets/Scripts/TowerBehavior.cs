using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    private Enemy currentTarget;
    [SerializeField] float attackRange;
    [SerializeField] int damage;
    [SerializeField] float reloadTime;
    LayerMask enemyLayer;

    private void Awake()
    {
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {        
        if (currentTarget == null)
        {            
            RaycastHit[] hit= Physics.BoxCastAll(transform.position, new Vector3(attackRange/2, attackRange / 2, attackRange / 2), Vector3.down,transform.rotation, 2f,enemyLayer);       // тут будет оверлапбокс чекаем все коллайдеры в кубе      
            if (hit.Length != 0)
            {
                for(int i =0; i < hit.Length; i++)
                {
                    Enemy enemy = hit[i].transform.GetComponent<Enemy>();
                    if (currentTarget == null)
                    {
                        currentTarget = enemy;
                    }
                    else
                    {
                        currentTarget = currentTarget.GetCoveredDistance() < enemy.GetCoveredDistance() ? enemy : currentTarget;
                    }
                }
            }
        }
        else if (Vector3.Distance(transform.position, currentTarget.transform.position) > attackRange)
        {
            currentTarget = null;
        }
    }    
}
