using System;
using UnityEngine;

public class TargetProvider
{
    public event Action<bool> TargetDirectionCalculated; //right false left true - spriteFlipX

    private Vector3 towerPosition;
    private float range;
    private string layer = "Enemy";
    private Transform targetTransform;

    public TargetProvider() { }
    
   
    public TargetProvider(Vector3 towerPosition, float range) :base()
    {
        this.towerPosition = towerPosition;
        this.range = range;
    }

    public bool TryGetTarget()
    {       
        RaycastHit[] hit = Physics.SphereCastAll(towerPosition, range, Vector3.down, 2f, LayerMask.GetMask(layer));
        if (hit.Length != 0)
        {
            Enemy currentEnemy = null;
            for (int i = 0; i < hit.Length; i++)
            {
                Enemy enemy = hit[i].transform.GetComponent<Enemy>();
                if (currentEnemy == null)
                {
                    currentEnemy = enemy;
                }
                else
                {
                    currentEnemy = currentEnemy.GetDistanceToLastNavPoint() <= enemy.GetDistanceToLastNavPoint() ? currentEnemy : enemy;
                }                
            }
            targetTransform = currentEnemy.transform;
            CalculateTargetDirection(towerPosition, targetTransform.position);
            return true;           
        }
        else
        {
            return false;
        }        
    }

    public bool TryGetTarget(Vector3 towerPosition, float range, string layer)
    {
        RaycastHit[] hit = Physics.SphereCastAll(towerPosition, range, Vector3.down, 2f, LayerMask.GetMask(layer));
        if (hit.Length != 0)
        {
            Enemy currentEnemy = null;
            for (int i = 0; i < hit.Length; i++)
            {
                Enemy enemy = hit[i].transform.GetComponent<Enemy>();
                if (currentEnemy == null)
                {
                    currentEnemy = enemy;
                }
                else
                {
                    currentEnemy = currentEnemy.GetDistanceToLastNavPoint() <= enemy.GetDistanceToLastNavPoint() ? currentEnemy : enemy;
                }
            }
            targetTransform = currentEnemy.transform;
            CalculateTargetDirection(towerPosition, targetTransform.position);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CalculateTargetDirection(Vector3 startPos, Vector3 targetPos)
    {
        if(startPos.x <= targetPos.x)
        {
            TargetDirectionCalculated?.Invoke(false);
        }
        else
        {
            TargetDirectionCalculated?.Invoke(true);
        }
    }

    public Transform GetTarget()
    {
        return targetTransform;
    }
}
