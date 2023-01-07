
using UnityEngine;
using UnityEngine.UIElements;


public class MovingLinearBehaviour : MovingBehaviour
{
   public override Vector3 GetMovePoint()
    {
       return  Vector3.MoveTowards(transform.position, _targetProvider.GetTargetPoint(), _moveSpeed * Time.deltaTime);
    }

    /*AttackGO rotation to target code
    private  void Rotate()
    {
        Vector3 firstVector = transform.position + transform.right;
        Vector3 secondVector = new Vector3(targetTransform.position.x - transform.position.x, transform.position.y, targetTransform.position.z - transform.position.z);
        float angle = Vector3.SignedAngle(firstVector, secondVector, transform.position + Vector3.up);
        transform.eulerAngles = new Vector3(90, 0, -angle);
        animator.Play(0);
    }*/    
}
