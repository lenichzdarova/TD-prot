using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ENEMY_NAMES
{
    Sphere,
    Cub,
    Capsule
}

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] int hp;
    [SerializeField] float speed;

    [SerializeField] int damage;
    [SerializeField] int gold;

    private NavigationPoint nextNavPoint;
    private Vector3 destination;
    private float CoveredDistance;

    private void Update()
    {
        Moving();        
    }
     
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void ChangeHP(int value)
    {        
        hp +=value;
    }

    public void SetPath(NavigationPoint n)
    {
        nextNavPoint = n.GetNextNavigationPoint();
        destination = n.GetDestination(); 
        destination.y = transform.transform.position.y;
        if (n.GetOrientation() == EnemyOrient.Right)
        {
            if(transform.localScale.x > 0)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }                        
        }
        else
        {
            if (transform.localScale.x < 0)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
        
    }
    private void Moving()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        CoveredDistance += Vector3.Distance(transform.position, position); 
        transform.position = position;
        if (transform.position == destination)
        {
            SetPath(nextNavPoint);
        }
        Debug.Log(CoveredDistance);
    }

    public float GetCoveredDistance()
    {
        return CoveredDistance;
    }
}
