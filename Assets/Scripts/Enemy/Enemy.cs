
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] EnemyType _enemyType;
    public event Action<Enemy> AskForRecycle;
    
    private EnemyAnimatorHandler _animatorHandler;
    private SpriteRendererHandler _spriteRenderer;
    private EnemyMovingHandler _enemyMovingHandler;    
    private Health _health;    
    private Coroutine _mainLoop;

    public void Initialize(NavigationPoint initialNavPoint)
    {
        _animatorHandler = new EnemyAnimatorHandler( GetComponent<Animator>());
        _spriteRenderer = new SpriteRendererHandler( GetComponent<SpriteRenderer>());             
        _health = new Health(GetStats().MaxHealth);
        _health.HealthChanged += healthBar.SetHealth;
        _health.Death += OnDeath;
        healthBar.Initialize(_health.GetMaxHealth());
        _enemyMovingHandler = new EnemyMovingHandler(transform,initialNavPoint, GetStats().Speed);
        _enemyMovingHandler.MovingDirection += _spriteRenderer.SetDirection;        
        _mainLoop = StartCoroutine(MainLoop());
    } 

    private EnemyStats GetStats()
    {
        var statsProvider = new BaseEnemyStats(_enemyType);
        return statsProvider.GetStats();
    }

    public float GetDistanceToPlayerBase()
    {
        return _enemyMovingHandler.GetDistanceToLastNavPoint();
    }    

    public void TakeDamage(AttackStats attackStats) 
    {
        int armor = GetStats().Armor - attackStats.ArmorPiercing;
        if (armor < 0) 
            armor = 0;
        int DamageArmorDebuff = attackStats.GetDamage() * armor / 100;
        int damage = attackStats.GetDamage() - DamageArmorDebuff;
        _health.RemoveHealth(damage);
    }

    public int GetBounty()
    {
        return GetStats().Bounty;
    }  
   
    private void OnDeath()
    {
        StopCoroutine(_mainLoop);
        _animatorHandler.DeathAnimation();        
        StartCoroutine(EnemyDeleting());
    }
    private IEnumerator EnemyDeleting()
    {
        float timeToDelete = 2.5f;
        yield return new WaitForSeconds(timeToDelete);
        AskForRecycle?.Invoke(this);
    }    
    public void AttackPlayer(Health playerHealth)
    {
        playerHealth.RemoveHealth(GetStats().Damage);
        AskForRecycle?.Invoke(this);
    }
    private IEnumerator MainLoop()
    {
        while (true)
        {
            _enemyMovingHandler.Move();
            yield return null;
        }
    }
}
