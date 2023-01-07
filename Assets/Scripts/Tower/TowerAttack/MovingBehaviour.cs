using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingBehaviour : MonoBehaviour
{    
    private protected float _moveSpeed;
    private protected TargetCoordinatesProvider _targetProvider;    

    public abstract Vector3 GetMovePoint();

    public virtual void Initialize(TargetCoordinatesProvider targetProvider, float moveSpeed)
    {
        _targetProvider = targetProvider;        
        _moveSpeed = moveSpeed;
    }    
}
