using UnityEngine;

/// <summary>
/// Конфигурация данных ближнего боя врага
/// </summary>
[CreateAssetMenu(fileName = "Enemy Melee", menuName = "Configs/Enemy Melee Data")]
public class EnemyMeleeDataConfig : EnemyDataConfigBase
{
    [Header("Melee Specific Settings")]
    [SerializeField] private float _attackRange = 1.5f; // Дистанция атаки ближнего боя
    [SerializeField] private float _knockbackForce = 5f; // Сила отталкивания
    
    // Properties
    public float AttackRange => _attackRange;
    public float KnockbackForce => _knockbackForce;
}
