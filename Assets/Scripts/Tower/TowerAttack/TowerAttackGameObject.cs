using System;
using UnityEngine;

public class TowerAttackGameObject : MonoBehaviour
{    
    [SerializeField] TargetCoordinatesProvider targetCoordinatesProvider;
    [SerializeField] MovingBehaviour movingBehaviour;
    
    private protected Vector3 startPositionLocal = default;    
    public void Initialize(Transform targetTransform)
    {

    }

    

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
