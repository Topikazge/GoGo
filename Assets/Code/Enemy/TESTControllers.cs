using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер тестирования врагов - управляет спавном и поведением врагов
/// </summary>
public class TESTControllers : MonoBehaviour, IHitEnemies
{
    [Header("Target Settings")]
    [SerializeField] private Transform _target;
    
    [Header("Enemy Configurations")]
    [SerializeField] private EnemyMeleeDataConfig _enemyMeleeData;
    [SerializeField] private EnemyMeleeDataConfig _enemyMeleeDataTwo;
    
    [Header("Spawn Settings")]
    [SerializeField] private int _amountEnemy;
    [SerializeField] private int _moveCount;
    [SerializeField] private float _spawnInterval = 1f; // Интервал спавна врагов (1 секунда по умолчанию)

    [Header("Enemy Management")]
    private List<EnemyMeleeData> _enemyMeleeView;
    private IEnemyFactory _enemyFactory;
    private EnemyPool _enemyPool;

    private void Start()
    {
        InitializeEnemySystem();
        StartCoroutine(EnemySpawnLoop());
    }

    /// <summary>
    /// Инициализация системы врагов
    /// </summary>
    private void InitializeEnemySystem()
    {
        _enemyFactory = new EnemyFactory();
        _enemyPool = new EnemyPool();
        _enemyMeleeView = new List<EnemyMeleeData>();
        
        if (_target == null)
        {
            Debug.LogError("Target not assigned in TESTControllers!");
        }
        
        if (_enemyMeleeData == null || _enemyMeleeDataTwo == null)
        {
            Debug.LogError("Enemy data configurations not assigned!");
        }
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }

    /// <summary>
    /// Применение урона к врагу
    /// </summary>
    /// <param name="target">Цель для нанесения урона</param>
    /// <param name="amount">Количество урона</param>
    /// <param name="source">Источник урона</param>
    public void ApplyHit(IDamageable target, int amount, GameObject source)
    {
        if (target is EnemyMeleeView enemyView && enemyView.Data != null)
        {
            EnemyMeleeData enemyMeleeData = enemyView.Data;
            enemyMeleeData.Health -= amount;
            
            if (enemyMeleeData.Health <= 0)
            {
                _enemyMeleeView.Remove(enemyView.Data);
                _enemyPool.ReturnInPool(enemyView);
                enemyView.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Применение урона персонажу от врага
    /// </summary>
    /// <param name="enemyHit">Враг, наносящий урон</param>
    public void ApplyDamageCharacter(IEnemyHit enemyHit)
    {
        // TODO: Реализовать логику урона персонажу
        // if (enemyHit != null && _target != null)
        // {
        //     // Применить урон к персонажу
        // }
    }

    /// <summary>
    /// Движение всех врагов к цели
    /// </summary>
    private void MoveToTarget()
    { 
        if (_target == null) return;
        
        foreach (EnemyMeleeData enemy in _enemyMeleeView)
        {
            if (enemy?.EnemyMeleeView != null)
            {
                enemy.EnemyMeleeView.MoveToTarget(_target.position);
            }
        }
    }

    /// <summary>
    /// Спавн нового врага
    /// </summary>
    private void OnSpawnEnemy()
    {
        if (_enemyPool.IsNotEmpty())
        {
            EnemyView objectFromPool = _enemyPool.GetObjectOrNull();
            if (objectFromPool is EnemyMeleeView enemy && enemy.Data != null)
            {
                _enemyMeleeView.Add(enemy.Data);
                enemy.gameObject.SetActive(true);
            }
        }
        else
        {
            // Создаём нового врага, если в пуле пусто
            EnemyMeleeData data = CreateNewEnemy();
            if (data != null)
            {
                _enemyMeleeView.Add(data);
            }
        }
    }

    /// <summary>
    /// Создание нового врага
    /// </summary>
    /// <returns>Данные созданного врага</returns>
    private EnemyMeleeData CreateNewEnemy()
    {
        // Чередуем типы врагов
        bool useFirstConfig = (_enemyMeleeView.Count % 2) == 0;
        EnemyMeleeDataConfig config = useFirstConfig ? _enemyMeleeData : _enemyMeleeDataTwo;
        
        if (config == null)
        {
            Debug.LogError("Enemy configuration is null!");
            return null;
        }
        
        return _enemyFactory.CreateEnemy(config);
    }

    /// <summary>
    /// Цикл спавна врагов
    /// </summary>
    /// <returns>Корутина</returns>
    private IEnumerator EnemySpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);
            OnSpawnEnemy();
        }
    }
}
