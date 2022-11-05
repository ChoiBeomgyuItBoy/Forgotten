using UnityEngine;

public class EnemyAnimationHandler : AnimationHandler
{
    [SerializeField] private Animator myAnimator;
    [SerializeField] private EnemyAttackHandler attackHandler;
    [SerializeField] private AttackDamage attackDamage;
  
    private readonly int LocomotionSpeedHash = Animator.StringToHash("Speed");
    private readonly int LocomotionBlendTreeHash = Animator.StringToHash("Locomotion");
    private readonly int DeathHash = Animator.StringToHash("Enemy_Death");

    private const float animationDampTime = 0.1f;

    // LOCOMOTION

    public void TransitionToLocomotion()
    {
        PlayAnimationSmoothly(myAnimator, LocomotionBlendTreeHash, animationDampTime);
    }

    public void PlayIdle(float deltaTime)
    {
        SetBlendTreeValue(myAnimator, LocomotionSpeedHash, 0, animationDampTime, deltaTime);
    }

    public void PlayRun(float deltaTime)
    {
        SetBlendTreeValue(myAnimator, LocomotionSpeedHash, 1, animationDampTime, deltaTime);
    }

    // COMBAT

    public void PlayRandomAttack()
    {
        int randomIndex = Random.Range(0, attackHandler.Attacks.Length);
        int nameHash = Animator.StringToHash(attackHandler.Attacks[randomIndex].AnimationName);

        attackDamage.SetAttack(attackHandler.Attacks[randomIndex].Damage);

        PlayAnimationSmoothly(myAnimator, nameHash, animationDampTime);
    }

    public void PlayDead()
    {
        PlayAnimationSmoothly(myAnimator, DeathHash, animationDampTime);
    }

    // TOOLS

    public bool AnimationIsOver(string animationTag)
    {
        if(GetNormalizedTime(myAnimator,animationTag) > 1f) 
        { 
            return true; 
        }
        else 
        { 
            return false; 
        }
    }
}