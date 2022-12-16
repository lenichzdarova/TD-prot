using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGroundTargetCoordinatesProvider : TargetCoordinatesProvider
{
    private Vector3 pointOnGround;

    public override void Init(Transform targetTransform)
    {
        pointOnGround = targetTransform.position;
    }

    public override Vector3 GetTargetPoint()
    {
        return pointOnGround;
    }
}
