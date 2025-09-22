using UnityEngine;

/// <summary>
/// Конфигурация данных оружия
/// </summary>
[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/WeaponData")]
public class WeaponDataConfig : ScriptableObject
{
    [Header("Weapon Info")]
    [SerializeField] private string _weaponName = "Default Weapon";
    
    [Header("Projectile Settings")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private int _baseProjectileCount = 1;
    [SerializeField] private float _baseSpeed = 10f;
    
    [Header("Combat Stats")]
    [SerializeField] private float _baseDamage = 10f;
    [SerializeField] private float _baseFireRate = 1f;
    [SerializeField] private float _baseRange = 5f;

    // Properties
    public string WeaponName => _weaponName;
    public GameObject ProjectilePrefab => _projectilePrefab;
    public float BaseDamage => _baseDamage;
    public float BaseFireRate => _baseFireRate;
    public int BaseProjectileCount => _baseProjectileCount;
    public float BaseRange => _baseRange; // Исправлена ошибка: было _baseProjectileCount
    public float BaseSpeed => _baseSpeed;
}