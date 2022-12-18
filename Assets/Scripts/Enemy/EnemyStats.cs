using System;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public event Action DeathBorderReach;

    [SerializeField] private int maxHealth, health, damage, bounty;
    [SerializeField] private float speed, armor;    

    public int MaxHealth 
    { 
        get =>maxHealth; 
        private set=> maxHealth = value; 
    }
    public int Health 
    { 
        get=>health;
        private set=> health = value; 
    }
    public int Damage 
    { 
        get=>damage; 
        private set=>damage=value; 
    }
    public int Bounty 
    { 
        get=>bounty; 
        private set=> bounty = value; 
    }
    public float Speed 
    { 
        get=>speed; 
        private set=>speed=value; 
    }
    public float Armor 
    { 
        get=>armor; 
        private set=>armor=value; 
    }

    public void AddHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health= maxHealth;
        }
        else if (health <= 0)
        {
            DeathBorderReach?.Invoke();
            speed= 0;
        }
    }   

}
