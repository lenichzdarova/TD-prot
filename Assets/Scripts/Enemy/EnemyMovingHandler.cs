
using System;
using UnityEngine;

public class EnemyMovingHandler
{
    public event Action<bool> MovingDirection; //сюда подписываем обертку спрайтрендерера, чтобы переворачивала спрайт по направлению.
    private Transform _transform;    
    private NavigationPoint _navPoint;    
    private float _distanceToLastNavPoint;
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
        if (_transform.position != _navPoint.GetCoordinates())
        {
            Vector3 pointToMove = Vector3.MoveTowards(_transform.position, _navPoint.GetCoordinates(), _speed*Time.deltaTime);
            _distanceToLastNavPoint -= Vector3.Distance(_transform.position,pointToMove);
            bool direction = MoveDirection(pointToMove);
            MovingDirection?.Invoke(direction);
            _transform.position = pointToMove;
        }
        else
        {
            _navPoint = _navPoint.GetNextNavigationPoint();
        }
    }

    public float GetDistanceToLastNavPoint()
    {
        return _distanceToLastNavPoint;
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
}
