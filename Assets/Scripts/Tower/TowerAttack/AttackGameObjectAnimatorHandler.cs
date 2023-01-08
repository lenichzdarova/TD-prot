using UnityEngine;

public class AttackGameObjectAnimatorHandler
{
    private Animator _animator;

    public AttackGameObjectAnimatorHandler(Animator animator)
    {
        _animator = animator;        
    }

    public void PlayImpactAnimation()
    {
        _animator.Play("Impact");
    }

    public void PlayMoveAnimation() 
    {
        _animator.Play("Move");
    }
}