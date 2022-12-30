using System;
using UnityEngine;

public class EnemyAnimatorHandler 
{
    public event Action AnimationEnd;
    public event Action AnimationAction;
    private protected Animator animator;

    public EnemyAnimatorHandler (Animator animator)
    {
        this.animator = animator;        
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
        animator.SetTrigger("Death");
    }
}

