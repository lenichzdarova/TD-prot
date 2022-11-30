using System;
using UnityEngine;


public class TowerAttack : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    private Vector3 startPositionLocal = default;    
    private Transform targetTransform;
    private Action  calback;    


    private void Update()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, targetTransform.position, speed*Time.deltaTime);

        Vector3 firstVector = new Vector3(transform.position.x, 0, transform.position.z)+ transform.right;
        Vector3 secondVector = new Vector3(targetTransform.position.x - transform.position.x, 0, targetTransform.position.z - transform.position.z);        
        float angle = Vector3.SignedAngle(firstVector, secondVector, transform.position+Vector3.up);          
        transform.eulerAngles = new Vector3(60,0,-angle);
        transform.position = position;
        
        if (transform.position == targetTransform.position)
        {
            animator.SetTrigger("Impact");                    
        }
    }

    private void OnTargetReach()
    {
        calback();
    }

    public void Initialize(Transform targetTransform,  Action calback, bool isFliped )
    {
        gameObject.SetActive(true);
        startPositionLocal = transform.localPosition;
        if (isFliped)
        {
            transform.localPosition = new Vector3(startPositionLocal.x * -1, startPositionLocal.y, startPositionLocal.z);
        }
        this.calback = calback;        
        this.targetTransform = targetTransform;
        this.calback = calback; 
    }    

    private void EndOfAnimation()
    {
        animator.SetTrigger("Fly");
        transform.localPosition = startPositionLocal;
        gameObject.SetActive(false);
    }
}
