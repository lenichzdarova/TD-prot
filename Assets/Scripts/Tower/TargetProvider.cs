using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProvider : MonoBehaviour
{
    public Transform TryToGetTarget(float range, string layer)
    {
        Transform currentTarget = null;
        RaycastHit[] hit = Physics.SphereCastAll(transform.position, range, Vector3.down, 2f, LayerMask.GetMask(layer));
        if (hit.Length != 0)
        {     
            switch (layer)
            {
                case "Enemy":
                    {
                        Enemy currentEnemy = null;
                        for (int i = 0; i < hit.Length; i++)
                        {                            
                            Enemy enemy = hit[i].transform.GetComponent<Enemy>();
                            if (currentEnemy == null)
                            {
                                currentEnemy = enemy;
                            }
                            else
                            {
                                currentEnemy = currentEnemy.GetDistanceToLastNavPoint() <= enemy.GetDistanceToLastNavPoint() ? currentEnemy : enemy;
                            }
                            currentTarget = currentEnemy.transform;
                        }
                        break;
                    }
                case "PointMark":
                    {
                        foreach(var rayHit in hit)
                        {
                            if (rayHit.transform.parent == this)
                            {
                                currentTarget = rayHit.transform;
                                break;
                            }
                        }
                        break;
                    }
                default:
                    {
                        currentTarget = hit[0].transform;
                        break;
                    }
            }            
        } 
        return currentTarget;
    }


}
