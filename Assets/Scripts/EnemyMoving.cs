using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving
{
    public Vector3 GetMovingPoint(Vector3 startPosition, Vector3 EndPosition, float speed)
    {        
        return Vector3.MoveTowards(startPosition, EndPosition, speed * Time.deltaTime);
    }
}
