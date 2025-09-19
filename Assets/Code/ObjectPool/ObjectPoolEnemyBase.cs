using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolEnemyBase<T> where T : EnemyView
{
    private Queue<T> _objects;

    public ObjectPoolEnemyBase()
    {
        _objects = new Queue<T>();
    }


    public bool IsNotEmpty()
    {
        return (_objects.Count == 0) ? false : true;
    }

    public T GetObjectOrNull()
    {
        if (_objects.Count == 0)
        {
            return default;
        }
        else
        {
            Debug.Log("Из пулла взяли врага");
            return _objects.Dequeue();
        }
    }

    public void ReturnInPool(T objectToReturn)
    {
        if ((objectToReturn is not null) && (objectToReturn is T))
        {
            Debug.Log(objectToReturn.gameObject.name + " Вошла в пул");
            _objects.Enqueue(objectToReturn);
        }

    }
    public void ClearPool()
    {
        _objects.Clear();
    }

    /*  protected void AddObjects()
      {
          var newObject = Instantiate<T>(_object);
          _objects.Enqueue(newObject);
      }*/
}