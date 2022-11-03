using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum EnemyOrient
{
    Left,
    Right
}
public class NavigationPoint : MonoBehaviour
{
    [SerializeField] NavigationPoint nextNavigationPoint;
    [SerializeField] EnemyOrient orientation;


    public Vector3 GetDestination()
    {
        return nextNavigationPoint.transform.position;
    }

    public NavigationPoint GetNextNavigationPoint()
    {
        if (nextNavigationPoint == null) 
        {
            nextNavigationPoint = this;
            
        }
        return nextNavigationPoint;
    }
    public EnemyOrient GetOrientation()
    {
        return orientation;
    }
}
