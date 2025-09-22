using UnityEngine;

/// <summary>
/// Обработчик попаданий, управляющий уроном между персонажем и врагами
/// </summary>
public class HitHandler : MonoBehaviour
{
    [Header("Hit Settings")]
    private IHitEnemies _hitEnemies;

    private void Start()
    {
        InitializeHitSystem();
    }

    /// <summary>
    /// Инициализация системы попаданий
    /// </summary>
    private void InitializeHitSystem()
    {
        IHitEnemies[] hitEnemies = FindObjectsByType<TESTControllers>(FindObjectsSortMode.None);
        
        if (hitEnemies.Length > 0)
        {
            _hitEnemies = hitEnemies[0];
        }
        else
        {
            Debug.LogWarning("No hit enemies controllers found in scene!");
        }
    }

    /// <summary>
    /// Применение урона от врага к цели
    /// </summary>
    /// <param name="damage">Количество урона</param>
    /// <param name="damageable">Цель, получающая урон</param>
    /// <param name="source">Источник урона</param>
    public void ApplyHitFromEnemy(int damage, IDamageable damageable, GameObject source)
    {
        if (_hitEnemies != null && damageable != null)
        {
            _hitEnemies.ApplyHit(damageable, damage, source);
        }
        else
        {
            Debug.LogWarning("Hit system not properly initialized or damageable is null!");
        }
    }

    /// <summary>
    /// Применение урона персонажу от врага
    /// </summary>
    /// <param name="damageable">Персонаж, получающий урон</param>
    public void ApplyCharacterHitFromEnemy(IDamageable damageable)
    {
        // TODO: Реализовать логику урона персонажу
        // if (_hitEnemies != null && damageable != null)
        // {
        //     _hitEnemies.ApplyHit(damageable, GetEnemyDamage(), gameObject);
        // }
    }
}
