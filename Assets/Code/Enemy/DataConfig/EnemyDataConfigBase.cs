using UnityEngine;

/// <summary>
/// Базовая конфигурация данных врага
/// </summary>
public abstract class EnemyDataConfigBase : ScriptableObject
{
    [Header("Enemy Type")]
    [SerializeField] private EnemyType _enemyType;
    
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 2f;
    
    [Header("Combat Settings")]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _attackInterval = 1f;
    
    [Header("Visual Settings")]
    [SerializeField] private Sprite _sprite;
    [SerializeField] private RuntimeAnimatorController _animatorController;
    
    [Header("Prefab Settings")]
    [SerializeField] private GameObject _prefab;
    
    [Header("Separation Settings")]
    [SerializeField] private EnemySeparationData _separationData;

    // Properties
    public EnemyType EnemyType => _enemyType;
    public float Speed => _speed;
    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public EnemySeparationData SeparationData => _separationData;
    public float AttackInterval => _attackInterval;
    public Sprite Sprite => _sprite;
    public RuntimeAnimatorController AnimatorController => _animatorController;
    public GameObject Prefab => _prefab;
}
