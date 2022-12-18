
using System;
using UnityEngine;

public class EnemyMovingHandler : MonoBehaviour
{
    public event Action<bool> MovingDirection; //сюда подписываем обертку спрайтрендерера, чтобы переворачивала спрайт по направлению.

    private EnemyMoving enemyMoving;
    private NavigationPoint navPoint;    
    private float distanceToLastNavPoint;
    private float speed;

    public void Init(NavigationPoint navPoint, float speed)
    {
        this.navPoint = navPoint;
        this.speed = speed;

        NavigationPoint temp = navPoint;
        while (temp.GetNextNavigationPoint()!=temp)
        {
            distanceToLastNavPoint += temp.DistanceToNext();
            temp = temp.GetNextNavigationPoint();
        }
        enemyMoving = new EnemyMoving(); // если надо будет менять принцип передвижения, тут вкорячу интерфейс
    }

    private void Update()
    {        
        if (transform.position != navPoint.GetDestination())
        {
            Vector3 pointToMove = enemyMoving.GetMovingPoint(transform.position, navPoint.GetDestination(), speed);
            distanceToLastNavPoint -= Vector3.Distance(transform.position,pointToMove);
            bool direction = transform.position.x <= pointToMove.x? true : false;
            MovingDirection?.Invoke(direction);
            transform.position = pointToMove;
        }
        else
        {
            navPoint = navPoint.GetNextNavigationPoint();
        }
    }

    public float GetDistanceToLastNavPoint()
    {
        return distanceToLastNavPoint;
    }       
}
