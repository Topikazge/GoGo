using UnityEngine;

public abstract class EnemyView : MonoBehaviour, IDamageable
{
    public abstract void TakeDamage(int amount);
}
