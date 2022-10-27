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

        Debug.Log($"{transform.name} health:{currentHealth}");
    }
}
