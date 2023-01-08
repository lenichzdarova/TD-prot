
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
    private EnemyMovingHandler _enemyMovingHandler; // can make abstraction here

    private EnemyStats _enemyStats; // possibly need decorator to implement slow mechanic
    private Health _health;    
    private Coroutine _mainLoop;

    public void Initialize(NavigationPoint initialNavPoint)
    {
        _animatorHandler = new EnemyAnimatorHandler( GetComponent<Animator>());
        _spriteRenderer = new SpriteRendererHandler( GetComponent<SpriteRenderer>());
        _enemyStats = new EnemyStats(_enemyType);      
        _health = new Health(_enemyStats._maxHealth);
        _health.HealthChanged += healthBar.SetHealth;
        _health.Death += OnDeath;
        healthBar.Initialize(_enemyStats._maxHealth);
        _enemyMovingHandler = new EnemyMovingHandler(transform,initialNavPoint, _enemyStats._speed);
        _enemyMovingHandler.MovingDirection += _spriteRenderer.SetDirection;        
        _mainLoop = StartCoroutine(MainLoop());
    } 

    public float GetDistanceToPlayerBase()
    {
        return _enemyMovingHandler.GetDistanceToLastNavPoint();
    }    

    public void TakeDamage(AttackStats attackStats) 
    {
        int armor = -_enemyStats._armor - attackStats.ArmorPiercing;
        if (armor < 0) 
            armor = 0;
        int DamageArmorDebuff = attackStats.GetDamage() * armor / 100;
        int damage = attackStats.GetDamage() - DamageArmorDebuff;
        _health.RemoveHealth(damage);
    }

    public int GetBounty()
    {
        return _enemyStats._bounty;
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
        playerHealth.RemoveHealth(_enemyStats._damage);
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
