using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [field: Header("References")]
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public EnemyAnimationHandler AnimationHandler { get; private set; }
    [field: SerializeField] public EnemyHealth EnemyHealth { get; private set; }
    [field: SerializeField] public GameObject[] ItemsToDrop { get; private set; }

    [field: Header("Values")]
    [field: SerializeField] [field: Range(0.1f, 20f)] public float MovementSpeed { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 50f)] public float ChaseRange { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] public float AttackRange { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] public float RotationSpeed { get; private set; }

    public PlayerHealth Player { get; private set; }

    private void Start()
    {
        EnemyHealth.onEnemyDead += HandleDeath;

        Player = FindObjectOfType<PlayerHealth>();

        Agent.updatePosition = false;
        Agent.updateRotation = false;

        SwitchState(new EnemyIdleState(this));
    }

    private void OnDisable()
    {
        EnemyHealth.onEnemyDead -= HandleDeath;
    }

    private void HandleDeath()
    {
        SwitchState(new EnemyDeadState(this));
    }

    private void OnDrawGizmosSelected()
    {
        // Chase Range Gizmos
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);

        // Attack Range Gizmos
        Gizmos.color = Color.red;

        Vector3 myPosition = transform.position;

        myPosition.y = myPosition.y + 1;

        Gizmos.DrawWireSphere(myPosition, AttackRange);
    }

}
