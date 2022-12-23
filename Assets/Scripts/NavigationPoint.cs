using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class NavigationPoint : MonoBehaviour
{
    [SerializeField] NavigationPoint nextNavigationPoint;   
    [SerializeField] Color gizmoColor;

    public Vector3 GetDestination()
    {       
        return transform.position;
    }

    public NavigationPoint GetNextNavigationPoint()
    {
        if (nextNavigationPoint == null) 
        {
            nextNavigationPoint = this;
        }
        return nextNavigationPoint;
    }    

    public float DistanceToNext()
    {
        return Vector3.Distance(GetDestination(), nextNavigationPoint.GetDestination());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, 0.3f);
    }

}
