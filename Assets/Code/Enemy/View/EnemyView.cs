using UnityEngine;

/// <summary>
/// Базовый класс представления врага
/// </summary>
public abstract class EnemyView : MonoBehaviour, IDamageable, IEnemyHit
{
    /// <summary>
    /// Урон, наносимый врагом
    /// </summary>
    public abstract int Damage { get; }

    /// <summary>
    /// Получение урона врагом
    /// </summary>
    /// <param name="amount">Количество урона</param>
    public abstract void TakeDamage(int amount);
}
