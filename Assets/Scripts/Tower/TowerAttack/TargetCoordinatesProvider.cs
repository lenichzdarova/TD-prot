using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetCoordinatesProvider : MonoBehaviour
{
    public abstract Vector3 GetTargetPoint();

    public abstract void Initialize(Transform targetTransform);
    
}
