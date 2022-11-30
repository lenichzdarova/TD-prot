
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
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

    private float slowSpeedModifier = 0.5f;
    private bool isSlowed;
    private Coroutine slowCorutine;

    private Spawner spawner;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        healthBar.Initialize(maxHP);
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
        float currentSpeed = isSlowed? speed*slowSpeedModifier : speed;

        Vector3 position = Vector3.MoveTowards(transform.position, destination, currentSpeed * Time.deltaTime);
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

    public void ApplyDamage(int damage, float slowInSeconds, int poison)
    {
        if (hp > 0)
        {
            if (slowInSeconds != 0)
            {
                if (slowCorutine != null)
                {
                    StopCoroutine(slowCorutine);                    
                }
                slowCorutine= StartCoroutine(slowApply(slowInSeconds));
            }
            hp -= damage;            
            healthBar.SetHealth(hp);
            if (hp <= 0)
            {
                speed = 0f;
                gameObject.layer = 6;
                animator.SetBool("IsDead", true);
                healthBar.gameObject.SetActive(false);
                //StopCoroutine(slowCorutine); разобраться как работает корутина
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

    private IEnumerator slowApply(float time)
    {
        isSlowed = true;
        yield return new WaitForSeconds(time);
        isSlowed= false;
    }
}
