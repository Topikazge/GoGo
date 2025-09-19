using UnityEngine;

public abstract class EnemyDataConfigBase : ScriptableObject
{
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private EnemySeparationData _separationData;
    [SerializeField] private float _attackInterval;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private RuntimeAnimatorController _animatorController;
    [SerializeField] private GameObject _prefub;

    public EnemyType EnemyType => _enemyType;
    public float Speed => _speed;
    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public EnemySeparationData SeparationData => _separationData;
    public float AttackInterval => _attackInterval;
    public Sprite Sprite => _sprite;

    public RuntimeAnimatorController AnimatorController => _animatorController;
    public GameObject Prefub => _prefub;
}
