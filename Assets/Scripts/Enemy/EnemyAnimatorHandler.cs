using System;
using UnityEngine;

public class EnemyAnimatorHandler 
{
    public event Action AnimationEnd;
    public event Action AnimationAction;
    private protected Animator _animator;

    public EnemyAnimatorHandler (Animator animator)
    {
        _animator = animator;        
    }    

    public void AnimationEventEndAnimation()
    {
        AnimationEnd?.Invoke();
    }  
    
    public void AnimationEventAction()
    {
        AnimationAction?.Invoke();
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger("Death");
    }
}

