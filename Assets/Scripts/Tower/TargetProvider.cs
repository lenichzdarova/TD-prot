using System;
using System.Collections.Generic;
using System.Linq;
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
            var target = GetClosestToPlayer(GetEnemiesArray(hit));
            _targetTransform = target.transform;
            CalculateTargetDirection(_towerPosition, _targetTransform.position);
            return true;           
        }
        else 
        {
            return false;            
        }        
    } 
    
    private Enemy[] GetEnemiesArray(RaycastHit[] hit)
    {
        Enemy[] enemies = new Enemy[hit.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = hit[i].transform.GetComponent<Enemy>();
        }
        return enemies;
    }
    private Enemy GetClosestToPlayer(Enemy[] enemiesArray)
    {
        enemiesArray.OrderBy(x => x.GetDistanceToPlayerBase());        
        enemiesArray.First();
        return enemiesArray.First();
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
