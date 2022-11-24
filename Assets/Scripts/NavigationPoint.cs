using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class NavigationPoint : MonoBehaviour
{
    [SerializeField] NavigationPoint nextNavigationPoint;   
    [SerializeField] Color gizmoColor;
    private float offset = 0.3f;
    


    public Vector3 GetDestination()
    {
        float offsetX=Random.Range(-offset, offset);
        float offsetZ = Random.Range(-offset, offset);
        Vector3 position = new Vector3(transform.position.x + offsetX,transform.position.y,transform.position.z+offsetZ);
        return position;
    }

    public NavigationPoint GetNextNavigationPoint()
    {
        if (nextNavigationPoint == null) 
        {
            nextNavigationPoint = this;
            
        }
        return nextNavigationPoint;
    }    

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, 0.3f);
    }

}
