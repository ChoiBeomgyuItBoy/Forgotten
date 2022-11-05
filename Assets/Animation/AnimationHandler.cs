using UnityEngine;

public abstract class AnimationHandler : MonoBehaviour
{
    protected void PlayAnimationSmoothly(Animator animator, int nameHash, float dampTime)
    {
        animator.CrossFadeInFixedTime(nameHash, dampTime, 0);
    }

    protected void SetBlendTreeValue(Animator animator, int nameHash, float value, float dampTime, float deltaTime)
    {
        animator.SetFloat(nameHash, value, dampTime, deltaTime);
    }

    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentAnimation = animator.GetCurrentAnimatorStateInfo(0);

        if(animator.IsInTransition(0)) 
        { 
            return 0f; 
        }

        else if(!animator.IsInTransition(0) && currentAnimation.IsTag(tag))
        {
            return animator.GetCurrentAnimatorStateInfo(0).normalizedTime;  
        }

        return 0f;
    }
}
