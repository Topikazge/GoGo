using UnityEngine;

/// <summary>
/// Интерфейс фабрики врагов
/// </summary>
public interface IEnemyFactory
{
    /// <summary>
    /// Создание врага ближнего боя
    /// </summary>
    /// <param name="data">Конфигурация данных врага</param>
    /// <returns>Данные созданного врага</returns>
    EnemyMeleeData CreateEnemy(EnemyMeleeDataConfig data);
    
    /// <summary>
    /// Создание врага дальнего боя
    /// </summary>
    /// <param name="data">Конфигурация данных врага</param>
    /// <returns>Данные созданного врага</returns>
    EnemyRangedData CreateEnemy(EnemyRangedDataConfig data);
}

