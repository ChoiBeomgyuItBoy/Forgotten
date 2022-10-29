using UnityEngine;

[RequireComponent(typeof(RevolverStateMachine))]
public class RevolverAnimationHandler : AnimationHandler
{
    [SerializeField] private Animator myAnimator;

    private readonly int FireHash = Animator.StringToHash("Revolver_Fire");
    private readonly int LocomotionBlendTreeHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private const float DampTime = 0.1f;
    private const float IdleBlendValue = 0f;
    private const float WalkBlendValue = 1f;

    public void PlayFireAnimation()
    {
        PlayAnimationSmoothly(myAnimator, FireHash, DampTime);
    }

    public void TransitionToLocomotion()
    {
        PlayAnimationSmoothly(myAnimator, LocomotionBlendTreeHash, DampTime);
    }

    public void PlayIdle(float deltaTime)
    {
        SetBlendTreeValue(myAnimator, SpeedHash, IdleBlendValue, DampTime, deltaTime);
    }

    public void PlayWalk(float deltaTime)
    {
        SetBlendTreeValue(myAnimator, SpeedHash, WalkBlendValue, DampTime, deltaTime);
    }
}
