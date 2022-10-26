using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimationHandler : AnimationHandler
{
    [SerializeField] private Animator myAnimator;

    // Locomotion Blend Tree
    private const float LocomotionTransitionTime = 0.1f;
    private const float IdleBlendValue = 0f;
    private const float IdleDampTime = 0.1f;
    private const float RunBlendValue  = 1f;
    private readonly int LocomotionBlendTreeHash = Animator.StringToHash("Locomotion");
    private readonly int LocomotionSpeedHash = Animator.StringToHash("Speed");

    public void TransitionToLocomotion()
    {
        PlayAnimationSmoothly(myAnimator, LocomotionBlendTreeHash, LocomotionTransitionTime);
    }

    public void PlayIdle(float deltaTime)
    {
        SetBlendTreeValue(myAnimator, LocomotionSpeedHash, IdleBlendValue, IdleDampTime, deltaTime);
    }

    public void PlayRun(float deltaTime)
    {
        SetBlendTreeValue(myAnimator, LocomotionSpeedHash, RunBlendValue, IdleDampTime, deltaTime);
    }
}