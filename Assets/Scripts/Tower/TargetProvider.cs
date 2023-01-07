using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetProvider
{
    public event Action<bool> TargetDirectionCalculated; //right false left true - spriteFlipX

    private Vector3 _towerPosition;
    private float _range;
    private LayerMask _layerMask = LayerMask.GetMask("Enemy");    
    private Transform _targetTransform;    
   
    public TargetProvider(Vector3 towerPosition, float range)
    {
        _towerPosition = towerPosition;
       _range = range;
    }

    public bool TryGetTarget()
    {       
        RaycastHit[] hit = Physics.SphereCastAll(_towerPosition, _range, Vector3.down, 2f, _layerMask);
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
                    currentEnemy = currentEnemy.GetDistanceToPlayerBase() <= enemy.GetDistanceToPlayerBase() ? currentEnemy : enemy;
                }                
            }
            _targetTransform = currentEnemy.transform;
            CalculateTargetDirection(_towerPosition, _targetTransform.position);
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
        return _targetTransform;
    }

    public List<Enemy> GetTarget(Vector3 impactPoint, float AOE)
    {        
        var targets = new List<Enemy>();
        if (AOE == 0)
        {
            if(_targetTransform != null)
            {
                targets.Add(_targetTransform.GetComponent<Enemy>());
            }            
            return targets;
        }
        else
        {
            Collider[] hit = Physics.OverlapSphere(impactPoint, AOE,_layerMask);
            foreach(var hitItem in hit)
            {
                targets.Add(hitItem.GetComponent<Enemy>());
            }            
            return targets;
        }
    }
}
