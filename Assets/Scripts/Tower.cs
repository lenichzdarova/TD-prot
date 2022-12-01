using System.Collections;
using UnityEngine;



public class Tower: MonoBehaviour
{
    [SerializeField] float attackRange;
    [SerializeField] float attackAOE;

    [SerializeField] float reloadTime;

    //hit modificators
    [SerializeField] int damage;
    [SerializeField] float slowInSeconds;
    [SerializeField] int poison;
   
    [SerializeField] GameObject attackGO;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    private Enemy currentTarget;
    
    private LayerMask enemyLayer;
    private bool isReadyToShoot = true;
    private bool isFliped;

    private void Awake()
    {
        enemyLayer = LayerMask.GetMask("Enemy");        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToShoot)
        {
            currentTarget = null;
            RaycastHit[] hit = Physics.SphereCastAll(transform.position, attackRange, Vector3.down, 2f, enemyLayer);            
            if (hit.Length != 0)
            {                
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
                    isFliped = false;
                }
                else if (transform.position.x > currentTarget.transform.position.x && spriteRenderer.flipX == false)
                {
                    spriteRenderer.flipX = true;
                    isFliped = true;
                }

                animator.SetTrigger("Attack");
                isReadyToShoot= false;
                StartCoroutine(Realoading());                
            }
        }
    }

    private void Activation()
    {
        if (currentTarget != null)
        {
            attackGO.GetComponent<TowerAttack>().Initialize(currentTarget.transform, Attack,isFliped);
        }
             
    }

    private IEnumerator Realoading()
    {
        yield return new WaitForSeconds(reloadTime);
        isReadyToShoot = true;
    }

    private void Attack()
    {
        if (attackAOE > 0)
        {
            Collider[] hit = Physics.OverlapSphere(currentTarget.transform.position, attackAOE, LayerMask.GetMask("Enemy"));
            foreach (Collider collider in hit)
            {
                Enemy enemy = collider.gameObject.GetComponent<Enemy>();
                enemy.ApplyDamage(damage, slowInSeconds, poison);
            }
        }
        else
        {
            currentTarget.ApplyDamage(damage, slowInSeconds, poison);
        }
    }   
    
    private void AttackAnimationEnd()
    {
        animator.SetTrigger("Idle");
    }

}
