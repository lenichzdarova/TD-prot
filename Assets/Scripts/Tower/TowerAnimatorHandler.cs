using UnityEngine;
using System;

public class TowerAnimatorHandler 
{
    public event Action EndAnimation;
    public event Action ActionAnimation;
    private Animator _animator;

    public TowerAnimatorHandler(Animator animator)
    {
        _animator = animator;
    }

    public void AnimationEventEndAnimation()
    {
        EndAnimation?.Invoke();
    }

    public void AnimationEventAction()
    {
        ActionAnimation?.Invoke();
    }
    public void PlayAttackAnimation()
    {
        _animator.SetTrigger("Attack");
    }
    public void PlayIdleAnimation()
    {
        _animator.SetTrigger("Idle");
    }
}
