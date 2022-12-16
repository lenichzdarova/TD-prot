using System;
using UnityEngine;

[RequireComponent(typeof(AttackStats))]

public class TowerSkillGameObject : MonoBehaviour
{    
    [SerializeField] AttackStats attackStats;
    [SerializeField] TargetCoordinatesProvider targetCoordinatesProvider;
    [SerializeField] MovingBehaviour movingBehaviour;

    //private protected Vector3 startPositionLocal = default;    
    

    private protected void Awake()
    {
        attackStats= GetComponent<AttackStats>();
        targetCoordinatesProvider = GetComponent<TargetCoordinatesProvider>();
        movingBehaviour = GetComponent<MovingBehaviour>();
    }

    private void Update()
    {
        movingBehaviour.Move();
    }    
    
    public virtual void Initialize(Transform targetTransform)
    {
        targetCoordinatesProvider.Init(targetTransform);
        movingBehaviour.Initialize( targetCoordinatesProvider);        
    }    
    /*
    private protected void EndOfAnimation()
    {        
        transform.localPosition = startPositionLocal;
        gameObject.SetActive(false);
    }

    private protected void OnTargetReach()
    {

    }
    */
}
