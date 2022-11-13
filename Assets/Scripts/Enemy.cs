
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
    private float CoveredDistance;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if(destination!= null)
        {
            Moving();
        }        
    }
     
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void ChangeHP(int value)
    {        
        hp +=value;
    }

    public void SetPath(NavigationPoint n)
    {
        nextNavPoint = n.GetNextNavigationPoint();
        destination = n.GetDestination(); 
        //destination.y = transform.transform.position.y;
        /*
        if (n.GetOrientation() == EnemyOrient.Left)
        {
            if(transform.localScale.x > 0)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }                        
        }
        else
        {
            if (transform.localScale.x < 0)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
        */
    }
    private void Moving()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        CoveredDistance += Vector3.Distance(transform.position, position);
        if (transform.position.x< position.x&& transform.localScale.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        else if (transform.position.x > position.x && transform.localScale.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        transform.position = position;
        if (transform.position == destination)
        {
            SetPath(nextNavPoint);
        }        
    }

    public float GetCoveredDistance()
    {
        return CoveredDistance;
    }

    public void ApplyDamage(int damage, float slow, int poison)
    {
        hp -= damage;
        if(hp <= 0)
        {
            speed = 0f;
            gameObject.layer = 6;
            animator.SetBool("IsDead", true);
            StartCoroutine(CleanCorps());
        }
    }

    

    private IEnumerator CleanCorps()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
