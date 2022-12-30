using System;
using System.Collections;
using UnityEngine;

public class TowerAttackHandler : MonoBehaviour 
{
    public event Action Activation;
    public event Action<bool> DirectionCheck;

    private AttackStats _attackStats;
    private TargetProvider _targetProvider;
    private TowerAttackGameObject _towerAttackGameObject;
    
    public void Initialize(AttackStats attackStats)
    {
        _attackStats = attackStats;
        _targetProvider = new TargetProvider(transform.position,attackStats.Range);
        _targetProvider.TargetDirectionCalculated += OnTargetDirectionCalculated;
        StartCoroutine(TryToAttack());
    }
    private IEnumerator TryToAttack()
    {        
        while (!_targetProvider.TryGetTarget())
        {          
            yield return null;            
        }
        Activate();
        StartCoroutine(Reload());
    }
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_attackStats.ReloadTime);
        StartCoroutine(TryToAttack());
    }
    private void Activate()
    {
        //sprite flipX event
        Activation?.Invoke();
    }
    public void OnActionAnimation()
    {
        //attackobject activation
        //targetprovider.gettarget
    }

    private void OnTargetDirectionCalculated(bool direction)
    {
        DirectionCheck?.Invoke(direction);
    }
}
