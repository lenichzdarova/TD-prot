
using System.Collections;
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

    [SerializeField] int damage;
    [SerializeField] int gold;    

    private NavigationPoint nextNavPoint;
    private Vector3 destination;
    private float distanceToLastNavPoint;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Spawner spawner;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if(destination!= null)
        {
            Moving();
        }        
    }    

    public void SetPath(NavigationPoint n)
    {
        nextNavPoint = n.GetNextNavigationPoint();
        destination = nextNavPoint.GetDestination();         
    }

    public void SetSpawner(Spawner spawner)
    {
        this.spawner= spawner;
    }

    private void Moving()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        distanceToLastNavPoint -= Vector3.Distance(transform.position, position);
        if (transform.position.x< position.x&& spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX= false;           
        }
        else if (transform.position.x > position.x && spriteRenderer.flipX == false)
        {
            spriteRenderer.flipX = true;
        }

        transform.position = position;
        if (transform.position == destination)
        {
            SetPath(nextNavPoint);
        }        
    }

    public float GetDistance()
    {
        return distanceToLastNavPoint;
    }

    public void SetDistance(float distance)
    {
        distanceToLastNavPoint= distance;
    }

    public void ApplyDamage(int damage, float slow, int poison)
    {
        if (hp > 0)
        {
            hp -= damage;
            if (hp <= 0)
            {
                speed = 0f;
                gameObject.layer = 6;
                animator.SetBool("IsDead", true);
                spawner.Recycle(this);
            }
        }
        else
        {
            return; 
        }
    }

    public int GetGold()
    {
        return gold;
    }    
}
