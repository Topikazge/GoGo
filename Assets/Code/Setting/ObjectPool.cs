using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T: class
{
    private Queue<T> _objects;

    public ObjectPool()
    {
        _objects = new Queue<T>();
    }

    public int Count => _objects.Count;

    public bool IsNotEmpty()
    {
        return _objects.Count > 0;
    }

    public T GetObjectOrNull()
    {
        if (_objects.Count == 0)
        {
            return default;
        }

        T obj = _objects.Dequeue();

        return obj;
    }

    public void ReturnInPool(T objectToReturn)
    {
        _objects.Enqueue(objectToReturn);
    }


    public void ClearPool()
    {
        _objects.Clear();
        Debug.Log("Пул объектов очищен");
    }


    public int GetPoolSize()
    {
        return _objects.Count;
    }
}
