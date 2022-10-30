using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    [field: SerializeField] public Attack[] Attacks { get; private set; }

    [SerializeField] private GameObject weapon1;
    [SerializeField] private GameObject weapon2;


    public void EnableWeapons()
    {
        weapon1.SetActive(true);
        weapon2.SetActive(true);
    }

    public void DisableWeapons()
    {
        weapon1.SetActive(false);
        weapon2.SetActive(false);
    }
}
