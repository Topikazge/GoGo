using UnityEngine;

/// <summary>
/// Пул объектов для врагов
/// </summary>
public class EnemyPool : ObjectPoolEnemyBase
{
    /// <summary>
    /// Инициализация пула врагов
    /// </summary>
    public void InitializePool()
    {
        // TODO: Добавить предварительное создание объектов в пуле
        Debug.Log("Пул врагов инициализирован");
    }
}
