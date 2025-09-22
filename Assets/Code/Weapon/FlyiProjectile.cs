using UnityEngine;

/// <summary>
/// Летящий снаряд для атаки врагов
/// </summary>
public class FlyingProjectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _radius = 0.2f;
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _lifetime = 5f;
    
    [Header("Movement")]
    private Vector2 _direction;
    private float _lifeTimer;
    
    private void Update()
    {
        Move();
        CheckEnemy();
        UpdateLifetime();
    }

    /// <summary>
    /// Движение снаряда
    /// </summary>
    private void Move()
    {
        if (_direction != Vector2.zero)
        {
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        }
    }

    /// <summary>
    /// Проверка столкновения с врагами
    /// </summary>
    private void CheckEnemy()
    {
        Collider2D enemyCollider = Physics2D.OverlapCircle(transform.position, _radius, _enemyLayerMask);
        if (enemyCollider == null)
            return;
            
        EnemyMeleeView enemy = enemyCollider.gameObject.GetComponent<EnemyMeleeView>();
        if (enemy != null)
        {
            ApplyDamage(enemy);
            DestroyProjectile();
        }
    }

    /// <summary>
    /// Применение урона к врагу
    /// </summary>
    /// <param name="enemy">Враг, получивший урон</param>
    private void ApplyDamage(EnemyMeleeView enemy) 
    {
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
            Debug.Log($"Снаряд попал в врага - {enemy.gameObject.name}");

        }
    }
    
    /// <summary>
    /// Обновление времени жизни снаряда
    /// </summary>
    private void UpdateLifetime()
    {
        _lifeTimer += Time.deltaTime;
        if (_lifeTimer >= _lifetime)
        {
            DestroyProjectile();
        }
    }
    
    /// <summary>
    /// Уничтожение снаряда
    /// </summary>
    private void DestroyProjectile()
    {
        // TODO: Добавить эффекты взрыва/попадания
        Destroy(gameObject);
    }

    /// <summary>
    /// Запуск снаряда
    /// </summary>
    /// <param name="direction">Направление полета</param>
    /// <param name="startPosition">Начальная позиция</param>
    public void Begin(Vector2 direction, Vector2 startPosition)
    {
        _direction = direction.normalized;
        transform.position = startPosition;
        _lifeTimer = 0f;
    }

    /// <summary>
    /// Остановка снаряда
    /// </summary>
    public void End()
    {
        _direction = Vector2.zero;
    }

    /// <summary>
    /// Отрисовка радиуса снаряда в редакторе
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}