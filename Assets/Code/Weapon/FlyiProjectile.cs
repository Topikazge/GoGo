using UnityEngine;

public class FlyiProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector2 _direction;

    private void Update()
    {
        Move();
        CheckEnemy();
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    private void CheckEnemy()
    {
        Collider2D enemyCollider = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
        if (enemyCollider == null)
            return;
        EnemyMeleeView enemy = enemyCollider.gameObject.GetComponent<EnemyMeleeView>();
        ApplyDamage(enemy);
    }

    private void ApplyDamage(EnemyMeleeView enemy) 
    {
        Debug.Log("Убил врага - " + enemy.gameObject.name);
    }


    public void Begin(Vector2 direction, Vector2 startPosition)
    {
        _direction = direction;
        transform.position = startPosition;
      
    }

    public void End()
    {
        _direction = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

}
