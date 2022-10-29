using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int MaxHealth;

    private int currentHealth;

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public void DealDamage(int damageAmount)
    {
        if(currentHealth <= 0) { return; }

        currentHealth = Mathf.Max(currentHealth - damageAmount, 0);

        if(currentHealth == 0) { Destroy(gameObject); }
    }
}
