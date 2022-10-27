using UnityEngine;

[RequireComponent(typeof(Animator), typeof(EnemyAttackHandler))]
public class EnemyAnimationHandler : AnimationHandler
{
    [SerializeField] private Animator myAnimator;
    [SerializeField] private EnemyAttackHandler attackHandler;
  
    // Locomotion Blend Tree
    private const float LocomotionTransitionTime = 0.1f;
    private const float IdleDampTime = 0.1f;
    private const float IdleBlendValue = 0f;
    private const float RunBlendValue  = 1f;
    private readonly int LocomotionBlendTreeHash = Animator.StringToHash("Locomotion");
    private readonly int LocomotionSpeedHash = Animator.StringToHash("Speed");

    // Attack
    private const float AttackTransitionTime = 0.1f;

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

    public void PlayRandomAttack()
    {
        int randomIndex = Random.Range(0, attackHandler.Attacks.Length);
        int nameHash = Animator.StringToHash(attackHandler.Attacks[randomIndex].AnimationName);

        PlayAnimationSmoothly(myAnimator, nameHash, AttackTransitionTime);
    }

    public bool AnimationIsOver()
    {
        if(GetNormalizedTime(myAnimator) >= 1f) 
        { 
            return true; 
        }
        else 
        { 
            return false; 
        }
    }
}