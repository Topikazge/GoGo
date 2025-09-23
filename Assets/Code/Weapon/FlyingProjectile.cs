using UnityEngine;

/// <summary>
/// Летящий снаряд для атаки врагов
/// </summary>
public class FlyingProjectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private int _damage;
    [SerializeField] private float _lifetime;
    private ProjectileGun _projectileGun;

    private Vector2 _direction;
    private float _lifeTimer;


    public void Intialization(ProjectileGun projectileGun)
    {
        _projectileGun = projectileGun;
    }

    
    private void Update()
    {
        Move();
        CheckEnemy();
        UpdateLifetime();
    }


    private void Move()
    {
        if (_direction != Vector2.zero)
        {
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        }
    }


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


    private void ApplyDamage(EnemyMeleeView enemy) 
    {
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
            Debug.Log($"Снаряд попал в врага - {enemy.gameObject.name}");
        }
    }

    private void UpdateLifetime()
    {
        _lifeTimer += Time.deltaTime;
        if (_lifeTimer >= _lifetime)
        {
            DestroyProjectile();
        }
    }
    

    private void DestroyProjectile()
    {
        SetActive(false);
        _projectileGun.ProjectileIsDeastroy(this);
    }


    public void Begin(Vector2 direction, Vector2 startPosition)
    {
        _direction = direction.normalized;
        transform.position = startPosition;
        _lifeTimer = 0f;
        SetActive(true);
    }

    public void End()
    {
        _direction = Vector2.zero;
    }

    private void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}