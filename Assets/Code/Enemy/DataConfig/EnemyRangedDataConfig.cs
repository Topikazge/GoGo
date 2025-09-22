using UnityEngine;

/// <summary>
/// Конфигурация данных дальнего боя врага
/// </summary>
[CreateAssetMenu(fileName = "Enemy Ranged", menuName = "Configs/Enemy Ranged Data")]
public class EnemyRangedDataConfig : EnemyDataConfigBase
{
    [Header("Ranged Specific Settings")]
    [SerializeField] private float _attackDistance = 5f; // Дистанция атаки дальнего боя
    [SerializeField] private float _projectileSpeed = 10f; // Скорость снаряда
    [SerializeField] private Transform _projectileSpawnPoint; // Точка спавна снаряда
    [SerializeField] private GameObject _projectilePrefab; // Префаб снаряда
    
    // Properties
    public float AttackDistance => _attackDistance;
    public float ProjectileSpeed => _projectileSpeed;
    public Transform ProjectileSpawnPoint => _projectileSpawnPoint;
    public GameObject ProjectilePrefab => _projectilePrefab;
}