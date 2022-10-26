using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    // Locomotion
    private readonly int LocomotionBlendTreeHash = Animator.StringToHash("Locomotion");
    private readonly int LocomotionSpeedHash = Animator.StringToHash("Speed");

    public void SetLocomotionBlendTree(float value, float dampTime, float deltaTime)
    {
        animator.SetFloat(LocomotionSpeedHash, value, dampTime, deltaTime);
    }

    public void PlayLocomotionBlendTree(float crossFadeDuration)
    {
        animator.CrossFadeInFixedTime(LocomotionBlendTreeHash, crossFadeDuration);
    }
}
