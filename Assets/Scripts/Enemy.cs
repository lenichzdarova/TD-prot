using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENEMY_NAMES
{
    Sphere,
    Cub,
    Capsule
}

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] int hp;
    [SerializeField] float speed;

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetHP(int maxHP)
    {
        this.maxHP = maxHP;
        hp = maxHP;
    }
}
