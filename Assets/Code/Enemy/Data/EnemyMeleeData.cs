using UnityEngine;

/// <summary>
/// Данные ближнего боя врага
/// </summary>
public class EnemyMeleeData : EnemyDataBase
{
    [Header("Melee Components")]
    private EnemyMeleeView _enemyMeleeView;
    
    /// <summary>
    /// Конструктор данных ближнего боя врага
    /// </summary>
    /// <param name="health">Здоровье врага</param>
    /// <param name="gameObject">Игровой объект врага</param>
    /// <param name="enemyDataConfigBase">Конфигурация данных врага</param>
    /// <param name="enemyMeleeView">Представление ближнего боя врага</param>
    public EnemyMeleeData(int health, GameObject gameObject, EnemyDataConfigBase enemyDataConfigBase, EnemyMeleeView enemyMeleeView) 
        : base(health, gameObject, enemyDataConfigBase)
    {
        EnemyMeleeView = enemyMeleeView;
    }

    // Properties
    public EnemyMeleeView EnemyMeleeView { get => _enemyMeleeView; set => _enemyMeleeView = value; }
}
