using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGroundTargetCoordinatesProvider : TargetCoordinatesProvider
{
    private Vector3 _pointOnGround;

    public override void Initialize(Transform targetTransform)
    {
        _pointOnGround = targetTransform.position;
    }

    public override Vector3 GetTargetPoint()
    {
        return _pointOnGround;
    }
}
