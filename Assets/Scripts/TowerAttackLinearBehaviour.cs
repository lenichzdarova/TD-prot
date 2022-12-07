
using UnityEngine;


public class TowerAttackLinearBehaviour : TowerAttackBehaviour
{
   private protected override void Move()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
        transform.position = position;

        if (transform.position == targetTransform.position&&isActive)
        {
            animator.SetTrigger("Impact"); 
            isActive= false;
        }
    }

    private protected override void Rotate()
    {
        Vector3 firstVector = transform.position + transform.right;
        Vector3 secondVector = new Vector3(targetTransform.position.x - transform.position.x, transform.position.y, targetTransform.position.z - transform.position.z);
        float angle = Vector3.SignedAngle(firstVector, secondVector, transform.position + Vector3.up);
        transform.eulerAngles = new Vector3(90, 0, -angle);
        animator.Play(0);
    }
}
