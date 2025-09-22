using UnityEngine;

/// <summary>
/// Конфигурация данных персонажа
/// </summary>
[CreateAssetMenu(fileName = "Character Config", menuName = "Configs/Character")]
public class CharacterDataConfig : ScriptableObject
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 5f;
    
    [Header("Health Settings")]
    [SerializeField] private int _health = 100;
    
    [Header("Combat Settings")]
    [SerializeField] private float _radiusApplyDamage = 1.5f;
    
    [Header("Prefab Settings")]
    [SerializeField] private GameObject _prefab;

    // Properties
    public float Speed => _speed;
    public int Health => _health;
    public float RadiusApplyDamage => _radiusApplyDamage;
    public GameObject Prefab => _prefab;
}
