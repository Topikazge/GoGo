using UnityEngine;

/// <summary>
/// Базовый класс для данных врагов
/// </summary>
public abstract class EnemyDataBase
{
    [Header("Enemy Stats")]
    private int _health;
    private GameObject _gameObject;
    private EnemyDataConfigBase _enemyDataConfigBase;

    /// <summary>
    /// Конструктор базового класса данных врага
    /// </summary>
    /// <param name="health">Здоровье врага</param>
    /// <param name="gameObject">Игровой объект врага</param>
    /// <param name="enemyDataConfigBase">Конфигурация данных врага</param>
    protected EnemyDataBase(int health, GameObject gameObject, EnemyDataConfigBase enemyDataConfigBase)
    {
        Health = health;
        GameObject = gameObject;
        EnemyDataConfigBase = enemyDataConfigBase;
    }

    // Properties
    public int Health { get => _health; set => _health = value; }
    public GameObject GameObject { get => _gameObject; set => _gameObject = value; }
    public EnemyDataConfigBase EnemyDataConfigBase { get => _enemyDataConfigBase; set => _enemyDataConfigBase = value; }
}
