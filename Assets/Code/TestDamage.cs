using UnityEngine;

public class TestDamage : MonoBehaviour
{
    [SerializeField] private float _radius = 1f;
    [SerializeField] private LayerMask _enemyLayer; // фильтр дл€ поиска только врагов
    [SerializeField] private float _attackCooldown = 1f; // задержка между ударами (секунды)

    private float _nextAttackTime = 0f;
    private TESTControllers tESTControllers;

    private void Start()
    {
        tESTControllers = FindFirstObjectByType<TESTControllers>();
    }

    private void Update()
    {
        if (Time.time < _nextAttackTime)
            return; // ещЄ не прошло врем€ Ч выход

        Collider2D hit = Physics2D.OverlapCircle(transform.position, _radius, _enemyLayer);

        if (hit != null)
        {
            IDamageable damageable = hit.GetComponent<IDamageable>();
            if (damageable != null)
            {
                tESTControllers.ApplyHit(damageable, 1, gameObject);
                _nextAttackTime = Time.time + _attackCooldown; // назначаем врем€ следующей атаки
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
