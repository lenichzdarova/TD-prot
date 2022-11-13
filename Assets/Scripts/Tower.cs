using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower: MonoBehaviour
{
    [SerializeField] float attackRange;    
    [SerializeField] float reloadTime;

    //hit modificators
    [SerializeField] int damage;
    [SerializeField] float slow;
    [SerializeField] int poison;

    //upgrades    
    [SerializeField] Sprite icon;
    [SerializeField] int cost;

    [SerializeField] TowerAttackType attackType;
    [SerializeField] GameObject attackGO;
    
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
                        currentTarget = currentTarget.GetCoveredDistance() < enemy.GetCoveredDistance() ? enemy : currentTarget;
                    }
                }

                Activation(currentTarget);
            }
        }
    }

    private void Activation(Enemy enemy)
    {
        isReadyToShoot = false;
        switch (attackType)
        {
            case TowerAttackType.Projectile:
                {
                    attackGO.GetComponent<Projectile>().Initialize(enemy, HitTarget);
                    break;
                }
            case TowerAttackType.AOE:
                {
                    break;
                }
            case TowerAttackType.Splash:
                {
                    attackGO.GetComponent<Splash>().Initialize(enemy.transform); 
                    break;
                }
        }
        StartCoroutine(Realoading());
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

    public int GetCost()
    {
        return cost;
    }    

    public Sprite GetIcon()
    {
        return icon;
    }

}
