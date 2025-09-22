using UnityEngine;

/// <summary>
/// Данные дальнего боя врага
/// </summary>
public class EnemyRangedData : EnemyDataBase
{
    [Header("Ranged Components")]
    private EnemyRangedView _enemyRangedView;
    
    /// <summary>
    /// Конструктор данных дальнего боя врага
    /// </summary>
    /// <param name="health">Здоровье врага</param>
    /// <param name="gameObject">Игровой объект врага</param>
    /// <param name="enemyDataConfigBase">Конфигурация данных врага</param>
    /// <param name="enemyRangedView">Представление дальнего боя врага</param>
    public EnemyRangedData(int health, GameObject gameObject, EnemyDataConfigBase enemyDataConfigBase, EnemyRangedView enemyRangedView) 
        : base(health, gameObject, enemyDataConfigBase)
    {
        EnemyRangedView = enemyRangedView;
    }

    // Properties
    public EnemyRangedView EnemyRangedView { get => _enemyRangedView; set => _enemyRangedView = value; }
}
