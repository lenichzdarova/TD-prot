
using UnityEngine;

public class NavigationPoint : MonoBehaviour
{
    [SerializeField] NavigationPoint _nextNavigationPoint;   
    [SerializeField] Color _gizmoColor;

    public Vector3 GetCoordinates()
    {       
        return transform.position;
    }

    public NavigationPoint GetNextNavigationPoint()
    {
        if (_nextNavigationPoint == null) 
        {
            return this;
        }
        return _nextNavigationPoint;
    }    

    public float DistanceToNext()
    {
        return Vector3.Distance(GetCoordinates(), _nextNavigationPoint.GetCoordinates());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawSphere(transform.position, 0.3f);
    }
}
