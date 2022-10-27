using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController), typeof(NavMeshAgent), typeof(ForceReceiver))]
[RequireComponent(typeof(EnemyAnimationHandler), typeof(Health))]
public class EnemyStateMachine : StateMachine
{
    [field: Header("References")]
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public EnemyAnimationHandler AnimationHandler { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }

    [field: Header("Values")]
    [field: SerializeField] [field: Range(0.1f, 20f)] public float MovementSpeed { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 50f)] public float ChaseRange { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] public float AttackRange { get; private set; }

    public GameObject Player { get; private set; }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Agent.updatePosition = false;
        Agent.updateRotation = false;

        SwitchState(new EnemyIdleState(this));
    }

    private void OnDrawGizmosSelected()
    {
        // Chase Range Gizmos
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);

        // Attack Range Gizmos
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

}
