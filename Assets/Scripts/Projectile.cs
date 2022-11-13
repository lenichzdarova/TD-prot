using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    Enemy target;
    Transform targetTransform;
    Action <Enemy> calback;

    private void Update()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, targetTransform.position, speed*Time.deltaTime);
        transform.position = position;
        if (transform.position == targetTransform.position)
        {
            calback(target);
            gameObject.SetActive(false);
            transform.localPosition = new Vector3(0, 0, 0);            
        }
    }

    public void Initialize(Enemy enemy, Action<Enemy>  calback )
    {
        this.calback = calback;
        target = enemy;
        targetTransform = enemy.transform;
        this.calback = calback;
        gameObject.SetActive(true);
    }
}
