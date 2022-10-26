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
}
