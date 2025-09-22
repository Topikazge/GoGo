using UnityEngine;

/// <summary>
/// Тестовый компонент для нанесения урона врагам в радиусе
/// </summary>
public class TestDamage : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private float _radius = 1f;
    [SerializeField] private LayerMask _enemyLayer; // Слой для поиска врагов
    [SerializeField] private float _attackCooldown = 1f; // Кулдаун между атаками (секунды)
    [SerializeField] private int _damageAmount = 1;

    [Header("Components")]
    private float _nextAttackTime = 0f;
    private TESTControllers _testControllers;

    private void Start()
    {
        InitializeComponents();
    }

    /// <summary>
    /// Инициализация компонентов
    /// </summary>
    private void InitializeComponents()
    {
        _testControllers = FindFirstObjectByType<TESTControllers>();
        
        if (_testControllers == null)
        {
            Debug.LogError("TESTControllers not found in scene!");
        }
    }

    private void Update()
    {
        if (Time.time < _nextAttackTime)
            return; // Еще не прошло время для атаки

        PerformAttack();
    }

    /// <summary>
    /// Выполнение атаки
    /// </summary>
    private void PerformAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _radius, _enemyLayer);

        if (hit != null)
        {
            IDamageable damageable = hit.GetComponent<IDamageable>();
            if (damageable != null && _testControllers != null)
            {
                _testControllers.ApplyHit(damageable, _damageAmount, gameObject);
                _nextAttackTime = Time.time + _attackCooldown; // Обновляем время следующей атаки
            }
        }
    }

    /// <summary>
    /// Отрисовка радиуса атаки в редакторе
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}