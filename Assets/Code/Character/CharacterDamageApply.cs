using UnityEngine;

/// <summary>
/// Компонент применения урона персонажем к врагам
/// </summary>
public class CharacterDamageApply : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private float _radiusApplyDamage = 1.5f;
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private int _damageAmount = 10;
    
    [Header("Performance")]
    [SerializeField] private float _damageCheckInterval = 0.1f;
    private float _lastDamageCheckTime;
    
    [Header("Components")]
    private HitHandler _hitHandler;

    private void Start()
    {
        InitializeComponents();
    }

    /// <summary>
    /// Инициализация компонентов
    /// </summary>
    private void InitializeComponents()
    {
        _hitHandler = FindAnyObjectByType<HitHandler>();
        
        if (_hitHandler == null)
        {
            Debug.LogError("HitHandler not found in scene!");
        }
    }

    /// <summary>
    /// Инициализация параметров урона
    /// </summary>
    /// <param name="radiusApplyDamage">Радиус применения урона</param>
    /// <param name="layerEnemy">Слой врагов</param>
    public void Init(float radiusApplyDamage, int layerEnemy)
    {
        _radiusApplyDamage = radiusApplyDamage;
        _enemyLayerMask = 1 << layerEnemy;
    }

    private void Update()
    {
        // Оптимизация: проверка урона не каждый кадр
        if (Time.time - _lastDamageCheckTime >= _damageCheckInterval)
        {
            CheckDamage();
            _lastDamageCheckTime = Time.time;
        }
    }

    /// <summary>
    /// Проверка и применение урона к врагам в радиусе
    /// </summary>
    public void CheckDamage()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(
            transform.position, 
            _radiusApplyDamage, 
            _enemyLayerMask
        );
        
        foreach (var enemyCollider in enemyColliders)
        {
            IEnemyHit damageDealer = enemyCollider.gameObject.GetComponent<IEnemyHit>();
            if (damageDealer != null && _hitHandler != null)
            {
                // TODO: Реализовать применение урона к врагу
                // _hitHandler.ApplyHitFromEnemy(_damageAmount, damageDealer, gameObject);
            }
        }
    }

    /// <summary>
    /// Отрисовка радиуса урона в редакторе
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 pos = transform.position;
        pos.z = 0; // Чтобы в 2D правильно отображалось
        Gizmos.DrawWireSphere(pos, _radiusApplyDamage);
    }
}

