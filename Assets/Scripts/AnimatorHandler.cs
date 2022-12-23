using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler 
{
    public event Action AnimationEnd;
    private Animator animator;

    public AnimatorHandler (Animator animator)
    {
        this.animator = animator;        
    }

    public void PlayAnimation(string animationName)
    {
        animator.SetTrigger(animationName);
    }

    public void EndOfClipAnimationEvent()
    {
        AnimationEnd?.Invoke();
    }   
}

