using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController), typeof(NavMeshAgent), typeof(ForceReceiver))]
public class EnemyStateMachine : StateMachine
{
    [field: Header("References")]
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }

    [field: Header("Values")]
    [field: SerializeField] [field: Range(0.1f, 50f)] public float PlayerChasingRange { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] public float MovementSpeed { get; private set; }

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
        Gizmos.DrawWireSphere(transform.position, PlayerChasingRange);
    }
}
