using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Controller.enabled = false;
        stateMachine.AnimationHandler.PlayDead();
    }

    public override void Tick(float deltaTime)
    {
        if(stateMachine.AnimationHandler.AnimationIsOver("Death")) 
        {
            DropRandomItem();
            MonoBehaviour.Destroy(stateMachine.gameObject);
        }   
    }

    public override void Exit() { }

    private void DropRandomItem()
    {
        int itemsLength = stateMachine.ItemsToDrop.Length;
        int randomIndex = Random.Range(0, itemsLength);

        GameObject item = MonoBehaviour.Instantiate(stateMachine.ItemsToDrop[randomIndex], stateMachine.transform);

        item.transform.parent = GameObject.FindObjectOfType<Pickups>().transform;
    }
}
