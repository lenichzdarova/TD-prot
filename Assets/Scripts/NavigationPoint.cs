using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPoint : MonoBehaviour
{
    [SerializeField] NavigationPoint nextNavigationPoint;

    public Vector3 GetDestination()
    {
        return nextNavigationPoint.transform.position;
    }

    public NavigationPoint GetNextNavigationPoint()
    {
        return nextNavigationPoint;
    }
}
