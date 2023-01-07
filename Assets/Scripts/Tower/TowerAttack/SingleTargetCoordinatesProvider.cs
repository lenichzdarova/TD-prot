using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetCoordinatesProvider : TargetCoordinatesProvider
{
    private Transform _targetTransform;
    private Vector3 _lastCoordinates;

    public override void Initialize(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }

    public override Vector3 GetTargetPoint()
    {
        if (_targetTransform != null)
        {
            _lastCoordinates = _targetTransform.position;
            return _lastCoordinates;
        }
        else
        {
            return _lastCoordinates;
        }        
    }
}
