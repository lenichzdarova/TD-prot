
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour
{

    public event Action<Enemy> AskForRecycle;

    [SerializeField] HealthBar healthBar;
    [SerializeField] EnemyType _enemyType; // maybe i can take it in waveSO and use as init args for different stats with same prefabs
      
    private EnemyAnimatorHandler _animatorHandler;
    private SpriteRendererHandler _spriteRenderer;
    private EnemyMovingHandler _enemyMovingHandler;    
    private Health _health;    
    private Coroutine _mainLoop;

    private bool _isSLowed;
    private Coroutine _slowCoroutine;

    public void Initialize(NavigationPoint initialNavPoint)
    {
        _animatorHandler = new EnemyAnimatorHandler( GetComponent<Animator>());
        _spriteRenderer = new SpriteRendererHandler( GetComponent<SpriteRenderer>());             
        _health = new Health(GetStats().MaxHealth);
        _health.HealthChanged += healthBar.SetHealth;
        _health.Death += OnDeath;
        healthBar.Initialize(_health.GetMaxHealth());
        _enemyMovingHandler = new EnemyMovingHandler(transform,initialNavPoint);
        _enemyMovingHandler.MovingDirection += _spriteRenderer.SetDirection;        
        _mainLoop = StartCoroutine(MainLoop());
    } 

    private EnemyStats GetStats()
    {
        IStatsProvider<EnemyStats> statsProvider = new BaseEnemyStats(_enemyType);
        if (_isSLowed)
        {
            statsProvider = new SlowEnemyStats(statsProvider);
        }
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
        SlowApply(attackStats.Slow);
    }

    public int GetBounty()
    {
        return GetStats().Bounty;
    }   
    private void OnDeath()
    {
        gameObject.layer = LayerMask.GetMask("DeadEnemy");
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
            _enemyMovingHandler.Move(GetStats().Speed);
            yield return null;
        }
    }

    private void SlowApply(bool isSlow)
    {
        if (isSlow)
        {
            if (_slowCoroutine != null)
            {
                StopCoroutine(_slowCoroutine);
            }
            _slowCoroutine = StartCoroutine(SlowRoutine());
        }
    }

    private IEnumerator SlowRoutine()
    {        
        float duration = 5f;
        _isSLowed = true;
        yield return new WaitForSeconds(duration);
        _isSLowed = false;
    }
}
