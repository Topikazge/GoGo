using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Базовый класс пула объектов для врагов
/// </summary>
/// <typeparam name="T">Тип объекта в пуле</typeparam>
public abstract class ObjectPoolEnemyBase<T> where T : EnemyView
{
    [Header("Pool Settings")]
    private Queue<T> _objects;
    private int _maxPoolSize = 50; // Максимальный размер пула

    /// <summary>
    /// Конструктор пула объектов
    /// </summary>
    public ObjectPoolEnemyBase()
    {
        _objects = new Queue<T>();
    }

    /// <summary>
    /// Проверка, есть ли объекты в пуле
    /// </summary>
    /// <returns>True, если в пуле есть объекты</returns>
    public bool IsNotEmpty()
    {
        return _objects.Count > 0;
    }

    /// <summary>
    /// Получение объекта из пула
    /// </summary>
    /// <returns>Объект из пула или null, если пул пуст</returns>
    public T GetObjectOrNull()
    {
        if (_objects.Count == 0)
        {
            return default;
        }
        
        T obj = _objects.Dequeue();
        if (obj != null)
        {
            Debug.Log($"Объект {obj.gameObject.name} взят из пула");
        }
        
        return obj;
    }

    /// <summary>
    /// Возврат объекта в пул
    /// </summary>
    /// <param name="objectToReturn">Объект для возврата в пул</param>
    public void ReturnInPool(T objectToReturn)
    {
        if (objectToReturn != null && _objects.Count < _maxPoolSize)
        {
            Debug.Log($"Объект {objectToReturn.gameObject.name} возвращен в пул");
            _objects.Enqueue(objectToReturn);
        }
        else if (_objects.Count >= _maxPoolSize)
        {
            Debug.LogWarning("Пул достиг максимального размера, объект не добавлен");
        }
    }
    
    /// <summary>
    /// Очистка пула
    /// </summary>
    public void ClearPool()
    {
        _objects.Clear();
        Debug.Log("Пул объектов очищен");
    }
    
    /// <summary>
    /// Получение количества объектов в пуле
    /// </summary>
    /// <returns>Количество объектов в пуле</returns>
    public int GetPoolSize()
    {
        return _objects.Count;
    }
}