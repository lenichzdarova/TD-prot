using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetCoordinatesProvider : TargetCoordinatesProvider
{
    private Transform targetTransform;
    private Vector3 lastCoordinates;

    public override void Init(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }

    public override Vector3 GetTargetPoint()
    {
        if (targetTransform != null)
        {
            lastCoordinates = targetTransform.position;
            return lastCoordinates;
        }
        else
        {
            return lastCoordinates;
        }        
    }
}
