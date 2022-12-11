using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTaskAutoAttack : TowerTask
{
    [SerializeField] TaskObjectBehaviour attackGO;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;   

    [SerializeField]
    private int minDamage;
    [SerializeField]
    private int maxDamage;
    [SerializeField]
    private float slowStrength;
    [SerializeField]
    private int armorPiercing;    
    [SerializeField]
    private float attackAOE;

    

    public int GetDamage()
    {
        return Random.Range(minDamage, maxDamage + 1);
    }

    private Enemy currentTarget;
    private bool isReady = true;
    private bool isFliped = false;

    public override bool Execute()
    {
        if (!isReady)
        {
            return false;
        }

        currentTarget = null;
        RaycastHit[] hit = Physics.SphereCastAll(transform.position, range, Vector3.down, 2f, LayerMask.GetMask("Enemy"));
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
                isReady = false;
                StartCoroutine(Realoading());
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Activation()
    {
        if (currentTarget != null)
        {
            attackGO.Initialize(currentTarget.transform, Attack, isFliped);             
            audioSource.PlayOneShot(audioClip);
        }
    }

    private IEnumerator Realoading()
    {
        yield return new WaitForSeconds(reloadTime);
        isReady = true;
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
                enemy.ApplyDamage();
            }
        }
        else if (currentTarget != null)
        {
            currentTarget.ApplyDamage();
        }
    }

    private void AttackAnimationEnd()
    {
        animator.SetTrigger("Idle");
    }
}
