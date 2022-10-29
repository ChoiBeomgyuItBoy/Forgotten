using UnityEngine;

public class RevolverShootState : RevolverBaseState
{
    private float delay;

    public RevolverShootState(RevolverStateMachine stateMachine, float delay) : base(stateMachine) 
    { 
        this.delay = delay;
    }

    public override void Enter() 
    { 
        stateMachine.AnimationHandler.PlayFireAnimation();
        stateMachine.PlayShootVFX();

        Shoot();
    }

    public override void Tick(float deltaTime) 
    { 
        delay -= deltaTime;

        if(delay <= 0f)
        {
            stateMachine.SwitchState(new RevolverIdleState(stateMachine));
        }
    }

    public override void Exit() { }

    private void Shoot()
    {
        stateMachine.CurrentBullets = Mathf.Max(stateMachine.CurrentBullets - 1, 0);

        RaycastHit hit = GetRayCastHit();

        if(hit.transform == null) { return; }

        if(hit.transform.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(stateMachine.ShootDamage);
        }

        stateMachine.PlayHitVFX(hit);
    }

    private RaycastHit GetRayCastHit()
    {
        RaycastHit hit;

        Vector3 center = stateMachine.MainCameraTransform.position;
        Vector3 forward = stateMachine.MainCameraTransform.transform.forward;

        float range = stateMachine.ShootRange;

        Physics.Raycast(center, forward, out hit, range);

        return hit;
    }
}
