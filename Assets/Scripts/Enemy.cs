using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
        transform.LookAt(destination);        
    }
    private void Moving()
    {       
        if ((transform.position - destination).magnitude < speed * Time.deltaTime)
        {
            transform.position = destination;
            SetPath(nextNavPoint);           
            return;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
}
