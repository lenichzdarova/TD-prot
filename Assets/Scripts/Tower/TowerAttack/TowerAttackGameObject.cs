using System;
using UnityEngine;

public abstract class TowerAttackGameObject : MonoBehaviour
{    
    [SerializeField] TargetCoordinatesProvider targetCoordinatesProvider;
    [SerializeField] MovingBehaviour movingBehaviour;
    

    //private protected Vector3 startPositionLocal = default;    
    public abstract void Initialize(Transform targetTransform);
    

    private void Update()
    {
        movingBehaviour.Move();
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
