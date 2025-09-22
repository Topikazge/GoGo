using UnityEngine;

/// <summary>
/// Пушка для стрельбы снарядами
/// </summary>
public class FlyingProjectileGun : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _projectileSpeed = 10f;
    
    [Header("Input")]
    [SerializeField] private KeyCode _fireKey = KeyCode.Space;
    
    private float _nextFireTime;
    
    private void Start()
    {
        InitializeGun();
    }

    /// <summary>
    /// Инициализация пушки
    /// </summary>
    private void InitializeGun()
    {
        if (_projectilePrefab == null)
        {
            Debug.LogError("Projectile prefab not assigned!");
        }
        
        if (_firePoint == null)
        {
            _firePoint = transform;
        }
    }

    private void Update()
    {
        HandleInput();
    }
    
    /// <summary>
    /// Обработка ввода
    /// </summary>
    private void HandleInput()
    {
        if (Input.GetKey(_fireKey) && CanFire())
        {
            Fire();
        }
    }
    
    /// <summary>
    /// Проверка возможности стрельбы
    /// </summary>
    /// <returns>True, если можно стрелять</returns>
    private bool CanFire()
    {
        return Time.time >= _nextFireTime;
    }
    
    /// <summary>
    /// Выстрел снарядом
    /// </summary>
    private void Fire()
    {
        if (_projectilePrefab == null) return;
        
        GameObject projectile = Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
        FlyingProjectile projectileScript = projectile.GetComponent<FlyingProjectile>();
        
        if (projectileScript != null)
        {
            Vector2 direction = _firePoint.right; // Направление стрельбы
            projectileScript.Begin(direction, _firePoint.position);
        }
        
        _nextFireTime = Time.time + 1f / _fireRate;
    }
}
