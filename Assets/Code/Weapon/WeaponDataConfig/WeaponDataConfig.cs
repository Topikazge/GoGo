using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/WeaponData")]
public class WeaponDataConfig : ScriptableObject
{
    [SerializeField] private string _weaponName;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _baseDamage;
    [SerializeField] private float _baseFireRate;
    [SerializeField] private int _baseProjectileCount;
    [SerializeField] private float _baseRange;
    [SerializeField] private float _baseSpeed;

    public string WeaponName => _weaponName;
    public GameObject ProjectilePrefab => _projectilePrefab;
    public float BaseDamage => _baseDamage;
    public float BaseFireRate => _baseFireRate;
    public int BaseProjectileCount => _baseProjectileCount;
    public float BaseRange => _baseProjectileCount;
    public float BaseSpeed => _baseSpeed;
}