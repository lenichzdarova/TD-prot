using System;
using System.Collections;
using UnityEngine;

public class TowerAttackHandler : MonoBehaviour 
{
    public event Action Activation;

    private TowerStats _towerStats;
    private TargetProvider _targetProvider;
    
    public void Initialize(TowerStats towerStats)
    {
        _towerStats = towerStats;
        _targetProvider= new TargetProvider(transform.position,_towerStats.GetRange());
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
        yield return new WaitForSeconds(_towerStats.GetRealoadTime());
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
}
