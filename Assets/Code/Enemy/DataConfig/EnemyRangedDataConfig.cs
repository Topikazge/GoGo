using UnityEngine;


[CreateAssetMenu(fileName = "EnemyRanged", menuName = "Configs/Enemy Ranged Data")]
public class EnemyRangedDataConfig : EnemyDataConfigBase
{
    [SerializeField] private float _attackDistance = 5f; // ��������� ��� �����
    //[SerializeField] private ProjectileType _projectilePrefab; // ������ �������
    [SerializeField] private Transform _projectileSpawnPoint; // ����� ������ �������

    public float AttackDistance => _attackDistance;
   // public ProjectileType ProjectilePrefab => _projectilePrefab;
    public Transform ProjectileSpawnPoint => _projectileSpawnPoint;
}
