
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyStats),typeof(Animator),typeof(SpriteRenderer))]
[RequireComponent(typeof(EnemyMovingHandler))]

public class Enemy : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    public event Action<Enemy> AskForRecycle;      

    private EnemyStats enemyStats;
    private AnimatorHandler animatorHandler;
    private SpriteRenderer spriteRenderer;
    private EnemyMovingHandler enemyMovingHandler;    

    public void Init(NavigationPoint initialNavPoint)
    {
        animatorHandler = new AnimatorHandler( GetComponent<Animator>());
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyStats = GetComponent<EnemyStats>();
        enemyMovingHandler = GetComponent<EnemyMovingHandler>();
        enemyStats.DeathBorderReach += OnDeathBorderReach;
        healthBar.Initialize(enemyStats.MaxHealth);
        enemyMovingHandler.Init(initialNavPoint, enemyStats.Speed);
    }   

    public float GetDistanceToLastNavPoint()
    {
        return enemyMovingHandler.GetDistanceToLastNavPoint();
    }    

    public void ApplyDamage(AttackStats attackStats)
    {
       enemyStats.AddHealth(-attackStats.GetDamage());
    }

    public int GetBounty()
    {
        return enemyStats.Bounty;
    }  
   
     private void OnDeathBorderReach()
    {
        animatorHandler.PlayDeathAnimation();        
        StartCoroutine(EnemyDeleting());
    }   

    private IEnumerator EnemyDeleting()
    {
        float timeToDelete = 2.5f;
        yield return new WaitForSeconds(timeToDelete);
        AskForRecycle?.Invoke(this);
    }    
    
    public void AttackPlayer(IPlayerDamage playerDamage)
    {
        playerDamage.ApplyDamage(enemyStats.Damage);
        AskForRecycle?.Invoke(this);
    }
}
