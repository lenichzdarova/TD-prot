using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler 
{
    private Animator animator;

    public AnimatorHandler (Animator animator)
    {
        this.animator = animator;
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger("Death");
    }    
}

