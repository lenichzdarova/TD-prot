
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
    private int _armor, _damage, _bounty;
    private float _speed;

    private Coroutine _mainLoop;

    public void Initialize(NavigationPoint initialNavPoint)
    {
        _animatorHandler = new EnemyAnimatorHandler( GetComponent<Animator>());
        _spriteRenderer = new SpriteRendererHandler( GetComponent<SpriteRenderer>());       
        StatsInitialization();
        _health.Death += OnDeath;
        healthBar.Initialize(_health.GetMaxHealth());
        _health.HealthChanged += healthBar.SetHealth;
        _enemyMovingHandler = new EnemyMovingHandler(transform,initialNavPoint, _speed);
        _enemyMovingHandler.MovingDirection += _spriteRenderer.SetDirection;
        _mainLoop = StartCoroutine(MainLoop());
    }  
    
    private void StatsInitialization()
    {
        var stats = new EnemyInitialStats(_enemyType);
        _health = new Health(stats._maxHealth);
        _armor = stats._armor;
        _damage = stats._damage;
        _bounty = stats._bounty;
        _speed = stats._speed;
    }

    public float GetDistanceToPlayerBase()
    {
        return _enemyMovingHandler.GetDistanceToLastNavPoint();
    }    

    public void TakeDamage(AttackStats attackStats) 
    {
        int armor = _armor - attackStats.ArmorPiercing;
        if (armor < 0) armor = 0;
        int DamageArmorDebuff = attackStats.GetDamage() * armor / 100;
        int damage = attackStats.GetDamage() - DamageArmorDebuff;
        _health.ChangeHealth(-damage);
    }

    public int GetBounty()
    {
        return _bounty;
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
    public void AttackPlayer(IPlayerHealthProvider iPlayerHealthProvider)
    {
        iPlayerHealthProvider.AddHealth(-_damage);
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
