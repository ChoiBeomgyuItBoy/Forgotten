using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    [field: SerializeField] public Attack[] Attacks { get; private set; }
}
