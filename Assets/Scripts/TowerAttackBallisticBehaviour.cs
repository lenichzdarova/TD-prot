
using UnityEngine;
using System;


public class TowerAttackBallisticBehaviour : TowerAttackBehaviour
{
    private Vector3 targetPoint;
    private float radius;
    private float distanceToApogee;
    Vector3 linearPosition;
    private float heighModifier = 3f;
    



    private protected override void Move()
    {
        if (isActive)
        {
            Vector3 tempLinearPosition = linearPosition;
            linearPosition = Vector3.MoveTowards(linearPosition, targetPoint, speed * Time.deltaTime);
            if(linearPosition == targetPoint)
            {
                transform.position = linearPosition;
                animator.SetTrigger("Impact");
                isActive = false;
                return;
            }
            float moveDelta = Vector3.Distance(tempLinearPosition, linearPosition);
            distanceToApogee -= moveDelta;            
            float cannonballHeigh;
            if (distanceToApogee == 0)
            {
                cannonballHeigh = radius;
            }
            else if (Mathf.Abs(distanceToApogee) >= radius)
            {
                cannonballHeigh = 0;
            }
            else
            {
                cannonballHeigh = Mathf.Sqrt(radius * radius - distanceToApogee * distanceToApogee);
            }

            Vector3 position = new Vector3(linearPosition.x, linearPosition.y + cannonballHeigh*heighModifier, linearPosition.z);
            transform.position = position;                   
        }       
    }

    private protected override void Rotate()
    {
        
    }

    public override void Initialize(Transform targetTransform, Action callback, bool isFliped)
    {
        gameObject.SetActive(true);
        startPositionLocal = transform.localPosition;
        if (isFliped)
        {
            transform.localPosition = new Vector3(-startPositionLocal.x, startPositionLocal.y, startPositionLocal.z);
        }
        this.callback = callback;
        this.targetTransform = targetTransform;
        targetPoint = targetTransform.position;

        linearPosition = transform.position;
        radius = Vector3.Distance(transform.position, targetPoint)/2;   
        distanceToApogee = radius;       
        
        Rotate();
    }
}
