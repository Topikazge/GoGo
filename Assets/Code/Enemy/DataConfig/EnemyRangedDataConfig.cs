using UnityEngine;


[CreateAssetMenu(fileName = "EnemyRanged", menuName = "Configs/Enemy Ranged Data")]
public class EnemyRangedDataConfig : EnemyDataConfigBase
{
    [SerializeField] private float _attackDistance = 5f; // Дистанция для атаки
    //[SerializeField] private ProjectileType _projectilePrefab; // Префаб снаряда
    [SerializeField] private Transform _projectileSpawnPoint; // Точка спавна снаряда

    public float AttackDistance => _attackDistance;
   // public ProjectileType ProjectilePrefab => _projectilePrefab;
    public Transform ProjectileSpawnPoint => _projectileSpawnPoint;
}
