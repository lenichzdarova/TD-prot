using UnityEngine;

public class AttackGameObjectAnimatorHandler
{
    private Animator _animator;
    private const string IMPACT_ANIMATION_STATE_NAME = "Impact";
    private const string MOVING_ANIMATION_STATE_NAME = "Move";

    public AttackGameObjectAnimatorHandler(Animator animator)
    {
        _animator = animator;        
    }

    public void PlayImpactAnimation()
    {
        _animator.Play(IMPACT_ANIMATION_STATE_NAME);
    }

    public void PlayMoveAnimation() 
    {
        _animator.Play(MOVING_ANIMATION_STATE_NAME);
    }
}