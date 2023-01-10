
using System;
using UnityEngine;

public class EnemyMovingHandler
{
    public event Action<bool> MovingDirection; 
    private Transform _transform;    
    private NavigationPoint _navPoint;    
    private float _distanceToLastNavPoint=0;
    private float _speed;

    public EnemyMovingHandler(Transform objectTransform, NavigationPoint navPoint, float speed)
    {
        _transform = objectTransform;
        _navPoint = navPoint;
        _speed = speed;
        CalculateDistanceToLastNavPoint();        
    }
    public void Move()
    {        
        if (_transform.position == _navPoint.GetCoordinates())
        {
            _navPoint = _navPoint.GetNextNavigationPoint();
        }
        Vector3 pointToMove = GetMoveVector();
        CalculateRemainDistance(pointToMove);       
        MovingDirection?.Invoke(MoveDirection(pointToMove));
        _transform.position = pointToMove;        
    }

    public float GetDistanceToLastNavPoint()
    {
        return _distanceToLastNavPoint;
    }   

    private Vector3 GetMoveVector()
    {
        return Vector3.MoveTowards(_transform.position, _navPoint.GetCoordinates(), _speed * Time.deltaTime);
    }

    private bool MoveDirection(Vector3 pointToMove)
    {
        return _transform.position.x <= pointToMove.x ? false : true;
    }
    
    private void CalculateDistanceToLastNavPoint()
    {
        NavigationPoint temp = _navPoint;
        float distance = 0;
        while (temp.GetNextNavigationPoint() != temp)
        {
            distance += temp.DistanceToNext();
            temp = temp.GetNextNavigationPoint();
        }
        _distanceToLastNavPoint = distance;
    }

    private void CalculateRemainDistance(Vector3 pointToMove)
    {
        _distanceToLastNavPoint -= Vector3.Distance(_transform.position, pointToMove);
    }
}
