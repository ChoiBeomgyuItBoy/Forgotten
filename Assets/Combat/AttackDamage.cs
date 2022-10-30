using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    
    private List<Collider> alreadyCollidedWith = new List<Collider>();

    private int damage;

    private void OnEnable()
    {
        alreadyCollidedWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == myCollider) { return; }

        if(alreadyCollidedWith.Contains(other)) { return; }

        alreadyCollidedWith.Add(other);

        if(other.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(damage);
        }
    }

    public void SetAttack(int damage)
    {
        this.damage = damage;
    }
}
