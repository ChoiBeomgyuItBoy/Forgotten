using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [field: SerializeField] public float MaxHealth { get; private set; }

    public float CurrentHealth { get; private set; }

    public event Action onHealthChange;
    public event Action onPlayerDead;

    private bool IsDead => CurrentHealth <= 0;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float amount)
    {
        if(IsDead) { return; }

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0f);

        onHealthChange?.Invoke();

        if(IsDead) { Die(); }
    }

    private void Die()
    {
        onPlayerDead?.Invoke();
    }
}
