
using System.Collections;
using Unity.VisualScripting;
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

    private float slowDuration = 10f;
    private bool isSlowed;
    private float slowStrength;
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
        float currentSpeed = isSlowed? speed-slowStrength : speed;
        if (currentSpeed < 0)
        {
            currentSpeed= 0;
        }

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

    public void ApplyDamage(int damage, float slowStrength, int armorPiercing)
    {
        
        if (hp > 0)
        {
            if (slowStrength != 0)
            {
                if (isSlowed)
                {
                    if (slowStrength >= this.slowStrength)
                    {
                        StopCoroutine(slowCorutine); 
                        this.slowStrength = slowStrength;                        
                        slowCorutine = StartCoroutine(slowApply());
                    }                                       
                }
                else
                {
                    this.slowStrength = slowStrength;
                    slowCorutine = StartCoroutine(slowApply());
                }                
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

    private IEnumerator slowApply()
    {
        isSlowed = true;
        yield return new WaitForSeconds(slowDuration);
        isSlowed= false;
    }

    public void ApplyWaveModifier(float hpMod)
    {
        float maxHPMod = maxHP * hpMod;
        maxHP = (int)maxHPMod;
        hp = maxHP;
    }
}
