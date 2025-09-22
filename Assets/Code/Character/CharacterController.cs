using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Контроллер персонажа, отвечающий за движение и обработку урона
/// </summary>
public class CharacterController : MonoBehaviour
{
    [Header("Character Configuration")]
    [SerializeField] private CharacterDataConfig _playerDataConfig;
    [SerializeField] private CharacterData _playerData;

    [Header("Components")]
    private InputContainer _inputContainer;
    private Rigidbody2D _rigidBody;

    [Header("Layer Settings")]
    [SerializeField] private LayerMask _enemyLayerMask;

    [Header("Movement")]
    private Vector2 _moveInput;


    private void Awake()
    {
        InitializeComponents();
        InitializePlayerData();
    }

    /// <summary>
    /// Инициализация компонентов
    /// </summary>
    private void InitializeComponents()
    {
        _inputContainer = FindFirstObjectByType<InputContainer>();
        _rigidBody = GetComponent<Rigidbody2D>();

        if (_inputContainer == null)
        {
            Debug.LogError("InputContainer not found in scene!");
        }

        if (_rigidBody == null)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }
    }

    /// <summary>
    /// Инициализация данных игрока
    /// </summary>
    private void InitializePlayerData()
    {
        if (_playerDataConfig != null && _playerData != null)
        {
            _playerData.CurrentHealth = _playerDataConfig.Health;
            _playerData.Speed = _playerDataConfig.Speed;
        }
        else
        {
            Debug.LogError("Player data configuration is missing!");
        }
    }

    private void Update()
    {

        _moveInput = _inputContainer.InputActions.Gameplay.Movement.ReadValue<Vector2>();
        CheckDamage();

    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Обработка движения персонажа 
    /// </summary>
    private void Move()
    {
        _rigidBody.linearVelocity = _moveInput * _playerData.Speed;
    }

    /// <summary>
    /// Проверка урона от врагов в радиусе
    /// </summary>
    private void CheckDamage()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(
            transform.position,
            _playerDataConfig.RadiusApplyDamage,
            _enemyLayerMask
        );

        if (enemyColliders.Length > 0)
        {
            ApplyDamage(enemyColliders);
        }
    }

    /// <summary>
    /// Применение урона от врагов
    /// </summary>
    /// <param name="enemyColliders">Массив коллайдеров врагов</param>
    private void ApplyDamage(Collider2D[] enemyColliders)
    {
        foreach (Collider2D enemyCollider in enemyColliders)
        {
            if (enemyCollider == null) continue;

            // Получаем компонент врага, который может наносить урон
            IEnemyHit enemyHit = enemyCollider.GetComponent<IEnemyHit>();
            if (enemyHit != null)
            {
                // Применяем урон к персонажу
                TakeDamageFromEnemy(enemyHit.Damage, enemyCollider.gameObject);
            }
        }
    }

    /// <summary>
    /// Получение урона от врага
    /// </summary>
    /// <param name="damage">Количество урона</param>
    /// <param name="enemySource">Источник урона (враг)</param>
    private void TakeDamageFromEnemy(int damage, GameObject enemySource)
    {
        _playerData.CurrentHealth -= damage;
        Debug.Log($"Персонаж получил {damage} урона от {enemySource.name}. Осталось здоровья: {_playerData.CurrentHealth}");

        // Проверяем, не погиб ли персонаж
        if (_playerData.CurrentHealth <= 0)
        {
            OnPlayerDeath();
        }
    }

    /// <summary>
    /// Обработка смерти персонажа
    /// </summary>
    private void OnPlayerDeath()
    {
       /* Debug.Log("Персонаж погиб!");

        // Останавливаем движение
        if (_rigidBody != null)
        {
            _rigidBody.linearVelocity = Vector2.zero;
        }

        // Отключаем компонент
        enabled = false;

        // TODO: Добавить логику смерти (анимация, звук, перезапуск уровня и т.д.)*/
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,
            _playerDataConfig.RadiusApplyDamage);
    }
}
