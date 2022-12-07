using System.Collections;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class Tower: MonoBehaviour
{
    [SerializeField] float attackRange;
    [SerializeField] float attackAOE;

    [SerializeField] float reloadTime;

    //hit modificators
    [SerializeField] int damage;
    [SerializeField] float slowStrength;
    [SerializeField] int armorPiercing;
   
    [SerializeField] TowerAttackBehaviour attackGO;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    private Enemy currentTarget;
    
    private LayerMask enemyLayer;
    private bool isReadyToShoot = true;
    private bool isFliped;

    private AudioSource audioSourse;

    private void Awake()
    {
        enemyLayer = LayerMask.GetMask("Enemy");  
        audioSourse= GetComponent<AudioSource>();
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
            attackGO.Initialize(currentTarget.transform, Attack,isFliped);
            audioSourse.PlayOneShot(audioSourse.clip);
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
            Collider[] hit = Physics.OverlapSphere(attackGO.transform.position, attackAOE, LayerMask.GetMask("Enemy"));
            Debug.Log(hit.Length);
            foreach (Collider collider in hit)
            {
                Enemy enemy = collider.gameObject.GetComponent<Enemy>();
                enemy.ApplyDamage(damage, slowStrength, armorPiercing);
            }
        }
        else if(currentTarget!=null)
        {
            currentTarget.ApplyDamage(damage, slowStrength, armorPiercing);
        }
    }   
    
    private void AttackAnimationEnd()
    {
        animator.SetTrigger("Idle");
    }

}
