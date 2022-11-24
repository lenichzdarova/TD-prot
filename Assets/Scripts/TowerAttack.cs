using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject ImpactVFX;
    Enemy target;
    Transform targetTransform;
    Action <Enemy> calback;
    float AOE;

    private void Update()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, targetTransform.position, speed*Time.deltaTime);
        transform.position = position;
        if (transform.position == targetTransform.position)
        {
            if(AOE > 0)
            {
                Collider[] hit = Physics.OverlapSphere(transform.position, AOE, LayerMask.GetMask("Enemy"));
                foreach(Collider collider in hit)
                {
                    Enemy enemy= collider.gameObject.GetComponent<Enemy>();
                    calback(enemy);
                }
            }
            else
            {
                calback(target);
            }
            Instantiate(ImpactVFX, position, ImpactVFX.transform.rotation); //сделать пул

            gameObject.SetActive(false);
            transform.localPosition = new Vector3(0, 0, 0);            
        }
    }

    public void Initialize(Enemy enemy, float AOE, Action<Enemy>  calback )
    {
        this.calback = calback;
        target = enemy;
        targetTransform = enemy.transform;
        this.calback = calback;
        this.AOE = AOE;
        gameObject.SetActive(true);
    }
}
