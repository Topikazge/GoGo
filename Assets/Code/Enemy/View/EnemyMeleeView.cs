using UnityEngine;

/// <summary>
/// Представление ближнего боя врага
/// </summary>
public class EnemyMeleeView : EnemyView
{
    [Header("Enemy Data")]
    private EnemyMeleeData _data;

    [Header("Components")]
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    // Properties
    public EnemyMeleeData Data => _data;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    public override int Damage 
    { 
        get 
        {
            // TODO: Реализовать получение урона из конфигурации
            return _data.EnemyDataConfigBase.Damage;
        } 
    }

    /// <summary>
    /// Инициализация представления ближнего боя врага
    /// </summary>
    /// <param name="data">Данные врага</param>
    /// <param name="spriteRenderer">Рендерер спрайта</param>
    /// <param name="rigidbody2D">Физический компонент</param>
    public void Init(EnemyMeleeData data, SpriteRenderer spriteRenderer, Rigidbody2D rigidbody2D)
    {
        _data = data;
        _spriteRenderer = spriteRenderer;
        _rigidbody2D = rigidbody2D;
    }

    /// <summary>
    /// Получение урона врагом
    /// </summary>
    /// <param name="amount">Количество урона</param>
    public override void TakeDamage(int amount)
    {
        if (_data != null)
        {
            _data.Health -= amount;
            
            if (_data.Health <= 0)
            {
                // Враг погиб
                OnEnemyDeath();
            }
        }
    }

    /// <summary>
    /// Обработка смерти врага
    /// </summary>
    private void OnEnemyDeath()
    {
        // TODO: Добавить логику смерти врага (анимация, звук, эффекты)
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Поворот спрайта врага
    /// </summary>
    /// <param name="flipSprite">Направление поворота</param>
    public void Flip(FlipSprite flipSprite)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.flipX = flipSprite == FlipSprite.Left;
        }
    }

    /// <summary>
    /// Движение к цели
    /// </summary>
    /// <param name="target">Позиция цели</param>
    public void MoveToTarget(Vector2 target)
    {
        if (_rigidbody2D == null || _data?.EnemyDataConfigBase == null) return;

        Vector2 currentPos = _rigidbody2D.position;
        Vector2 direction = (target - currentPos).normalized;

        Vector2 targetPosition = currentPos + direction * _data.EnemyDataConfigBase.Speed * Time.fixedDeltaTime;
        _rigidbody2D.MovePosition(targetPosition);
    }
}
