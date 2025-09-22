using UnityEngine;

/// <summary>
/// Фабрика для создания врагов
/// </summary>
public class EnemyFactory : IEnemyFactory
{
    /// <summary>
    /// Создание врага ближнего боя
    /// </summary>
    /// <param name="data">Конфигурация данных врага</param>
    /// <returns>Данные созданного врага</returns>
    public EnemyMeleeData CreateEnemy(EnemyMeleeDataConfig data)
    {
        if (data?.Prefab == null)
        {
            Debug.LogError("EnemyMeleeDataConfig or Prefab is null!");
            return null;
        }

        GameObject enemyObject = Object.Instantiate(data.Prefab);
        EnemyMeleeView enemyView = enemyObject.GetComponent<EnemyMeleeView>();
        SpriteRenderer spriteRenderer = enemyObject.GetComponent<SpriteRenderer>();
        Rigidbody2D rigidbody2D = enemyObject.GetComponent<Rigidbody2D>();

        if (enemyView == null || spriteRenderer == null || rigidbody2D == null)
        {
            Debug.LogError("Required components not found on enemy prefab!");
            Object.Destroy(enemyObject);
            return null;
        }

        enemyView.Init(new EnemyMeleeData(data.MaxHealth, enemyObject, data, enemyView), spriteRenderer, rigidbody2D);
        
        if (data.Sprite != null)
        {
            spriteRenderer.sprite = data.Sprite;
        }
        
        Animator animator = enemyObject.GetComponent<Animator>();
        if (animator != null && data.AnimatorController != null)
        {
            animator.runtimeAnimatorController = data.AnimatorController;
        }
        
        return enemyView.Data;
    }

    /// <summary>
    /// Создание врага дальнего боя
    /// </summary>
    /// <param name="data">Конфигурация данных врага</param>
    /// <returns>Данные созданного врага</returns>
    public EnemyRangedData CreateEnemy(EnemyRangedDataConfig data)
    {
        if (data?.Prefab == null)
        {
            Debug.LogError("EnemyRangedDataConfig or Prefab is null!");
            return null;
        }

        GameObject enemyObject = Object.Instantiate(data.Prefab);
        EnemyRangedView enemyView = enemyObject.GetComponent<EnemyRangedView>();
        SpriteRenderer spriteRenderer = enemyObject.GetComponent<SpriteRenderer>();
        Rigidbody2D rigidbody2D = enemyObject.GetComponent<Rigidbody2D>();

        if (enemyView == null || spriteRenderer == null || rigidbody2D == null)
        {
            Debug.LogError("Required components not found on ranged enemy prefab!");
            Object.Destroy(enemyObject);
            return null;
        }

        enemyView.Init(new EnemyRangedData(data.MaxHealth, enemyObject, data, enemyView), spriteRenderer, rigidbody2D);
        
        if (data.Sprite != null)
        {
            spriteRenderer.sprite = data.Sprite;
        }
        
        Animator animator = enemyObject.GetComponent<Animator>();
        if (animator != null && data.AnimatorController != null)
        {
            animator.runtimeAnimatorController = data.AnimatorController;
        }
        
        return enemyView.Data;
    }
}
