using UnityEngine;

public abstract class EnemyView : MonoBehaviour, IDamageable , IEnemyHit
{
    public abstract int Damage { get; }

    public abstract void TakeDamage(int amount);
}
