using UnityEngine;

[RequireComponent(typeof(RevolverStateMachine))]
public class RevolverAnimationHandler : AnimationHandler
{
    [SerializeField] private Animator myAnimator;
    private int FireHash = Animator.StringToHash("Revolver_Fire");
    private float FireDampTime = 0.1f;

    public void PlayFireAnimation()
    {
        PlayAnimationSmoothly(myAnimator, FireHash, FireDampTime);
    }
}
