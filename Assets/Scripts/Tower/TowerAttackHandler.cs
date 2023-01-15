using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackHandler : MonoBehaviour 
{
    public event Action Activation;
    public event Action<bool> DirectionCheck; //false == right
    
    private TargetProvider _targetProvider;
    [SerializeField]
    private TowerAttackGameObject _towerAttackGameObject;
    private TowerType _towerType;
    
    public void Initialize(TowerType towerType)
    {
        _towerType = towerType;
        _targetProvider = new TargetProvider(transform.position,GetStats().Range);
        _targetProvider.TargetDirectionCalculated += OnTargetDirectionCalculated;
        _towerAttackGameObject.Initialize();
        _towerAttackGameObject.TargetPointReach += OnTargetPointReach;        
        DirectionCheck += _towerAttackGameObject.OnDirectionCheck;
        StartCoroutine(TryToAttack());
    }

    private AttackStats GetStats()
    {
        IStatsProvider<AttackStats> stats = new BaseTowerAttackStats(_towerType);
        stats = new TowerUpgradesStatsProvider(stats,_towerType); 
        return stats.GetStats();
    }

    private IEnumerator TryToAttack()
    {        
        while (!_targetProvider.TryGetTarget())
        {            
            yield return null;            
        }
        Activate();        
    }
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(GetStats().ReloadTime);
        StartCoroutine(TryToAttack());
    }
    private void Activate()
    {        
        Activation?.Invoke();
    }
    public void OnActionAnimation()
    {
        var target = _targetProvider.GetTarget();
        if(target != null)
        {
            _towerAttackGameObject.Activate(target);
            StartCoroutine(Reload());
        }
        else
        {
            StartCoroutine(TryToAttack());
        }        
    }

    private void OnTargetDirectionCalculated(bool direction)
    {
        DirectionCheck?.Invoke(direction);
    }

    private void OnTargetPointReach(Vector3 targetPoint)
    {
        var targets = _targetProvider.GetTarget(targetPoint, GetStats().AOE);       
        foreach(var target in targets)
        {
            target.TakeDamage(GetStats());
        }
    }
}
