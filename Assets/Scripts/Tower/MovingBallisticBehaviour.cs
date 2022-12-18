
using UnityEngine;
using System;


public class MovingBallisticBehaviour : MovingBehaviour
{    
    private float radius;
    private float distanceToApogee;
    private Vector3 linearPosition;
    [SerializeField]
    private float heighModifier = 3f;

    public override void Move()
    {        
            Vector3 tempLinearPosition = linearPosition;
            linearPosition = Vector3.MoveTowards(linearPosition, targetProvider.GetTargetPoint(), moveSpeed * Time.deltaTime);
            if(linearPosition == targetProvider.GetTargetPoint())
            {
                transform.position = linearPosition;
                //тут какой-то колбек на активацию.
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

    public override void Initialize(TargetCoordinatesProvider targetProvider)
    {        
        startPositionLocal = transform.localPosition;
        
        this.targetProvider=targetProvider;

        linearPosition = transform.position;
        radius = Vector3.Distance(transform.position, targetProvider.GetTargetPoint())/2;   
        distanceToApogee = radius;        
    }
}
