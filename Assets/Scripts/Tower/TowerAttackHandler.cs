using System;
using System.Collections;
using UnityEngine;

public class TowerAttackHandler : MonoBehaviour 
{
    public event Action Activation;
    public event Action<bool> DirectionCheck; //false == right

    private AttackStats _attackStats;
    private TargetProvider _targetProvider;
    [SerializeField]
    private TowerAttackGameObject _towerAttackGameObject;
    
    public void Initialize(AttackStats attackStats)
    {
        _attackStats = attackStats;
        _targetProvider = new TargetProvider(transform.position,_attackStats.Range);
        _targetProvider.TargetDirectionCalculated += OnTargetDirectionCalculated;
        _towerAttackGameObject.Initialize();
        _towerAttackGameObject.TargetPointReach += OnTargetPointReach;        
        DirectionCheck += _towerAttackGameObject.OnDirectionCheck;
        StartCoroutine(TryToAttack());
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
        yield return new WaitForSeconds(_attackStats.ReloadTime);
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
        var targets = _targetProvider.GetTarget(targetPoint, _attackStats.AOE);       
        foreach(var target in targets)
        {
            target.TakeDamage(_attackStats);
        }
    }
}
