using UnityEngine;

/// <summary>
/// Представление дальнего боя врага
/// </summary>
public class EnemyRangedView : EnemyView
{
    [Header("Ranged Components")]
    private EnemyRangedData _data;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    
    // Properties
    public EnemyRangedData Data => _data;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    public override int Damage 
    { 
        get 
        {
            // TODO: Реализовать получение урона из конфигурации
            return _data?.EnemyDataConfigBase?.Damage ?? 1;
        } 
    }

    /// <summary>
    /// Инициализация представления дальнего боя врага
    /// </summary>
    /// <param name="data">Данные врага</param>
    /// <param name="spriteRenderer">Рендерер спрайта</param>
    /// <param name="rigidbody2D">Физический компонент</param>
    public void Init(EnemyRangedData data, SpriteRenderer spriteRenderer, Rigidbody2D rigidbody2D)
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
    /// Атака дальнего боя
    /// </summary>
    /// <param name="target">Цель для атаки</param>
    public void RangedAttack(Vector2 target)
    {
        // TODO: Реализовать логику дальнего боя (снаряды)
        if (_data?.EnemyDataConfigBase != null)
        {
            // Создать снаряд и направить к цели
        }
    }
}
