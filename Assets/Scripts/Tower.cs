using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower: MonoBehaviour
{
    [SerializeField] float attackRange;
    [SerializeField] float attackAOE;

    [SerializeField] float reloadTime;

    //hit modificators
    [SerializeField] int damage;
    [SerializeField] float slow;
    [SerializeField] int poison;
   
    [SerializeField] GameObject attackGO;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    
    LayerMask enemyLayer;
    bool isReadyToShoot = true;

    private void Awake()
    {
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToShoot)
        {
            RaycastHit[] hit = Physics.SphereCastAll(transform.position, attackRange, Vector3.down, 2f, enemyLayer);            
            if (hit.Length != 0)
            {
                Enemy currentTarget = null;
                for (int i = 0; i < hit.Length; i++)
                {
                    Enemy enemy = hit[i].transform.GetComponent<Enemy>();
                    if (currentTarget == null)
                    {
                        currentTarget = enemy;
                    }
                    else
                    {
                        currentTarget = currentTarget.GetDistance() <= enemy.GetDistance() ? currentTarget : enemy;
                    }
                }

                if (transform.position.x < currentTarget.transform.position.x && spriteRenderer.flipX == true)
                {
                    spriteRenderer.flipX = false;
                }
                else if (transform.position.x > currentTarget.transform.position.x && spriteRenderer.flipX == false)
                {
                    spriteRenderer.flipX = true;
                }

                animator.SetTrigger("Attack");
                isReadyToShoot= false;
                StartCoroutine(Realoading());
                StartCoroutine(Attack(currentTarget));
            }
        }
    }

    private void Activation(Enemy enemy)
    {            
        attackGO.GetComponent<TowerAttack>().Initialize(enemy , attackAOE, HitTarget);              
        //StartCoroutine(Realoading());
    }

    private IEnumerator Realoading()
    {
        yield return new WaitForSeconds(reloadTime);
        isReadyToShoot = true;
    }

    private void HitTarget(Enemy enemy)
    {
        enemy.ApplyDamage(damage,slow,poison);        
    }   

    private IEnumerator Attack(Enemy enemy)
    {
        AnimatorClipInfo[] clip = animator.GetCurrentAnimatorClipInfo(0);
        float time = clip[0].clip.averageDuration;
        yield return new WaitForSeconds(time);
        Activation(enemy);
        animator.SetTrigger("Idle");        
    }

}
