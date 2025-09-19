using UnityEngine;

public abstract class EnemyDataBase
{
    private int _health;
    private GameObject _gameobject;
    private EnemyDataConfigBase _enemyDataConfigBase;

    protected EnemyDataBase(int health, GameObject gameobject, EnemyDataConfigBase enemyDataConfigBase)
    {
        Health = health;
        Gameobject = gameobject;
        EnemyDataConfigBase = enemyDataConfigBase;
    }

    public int Health { get => _health; set => _health = value; }
    public GameObject Gameobject { get => _gameobject; set => _gameobject = value; }
    public EnemyDataConfigBase EnemyDataConfigBase { get => _enemyDataConfigBase; set => _enemyDataConfigBase = value; }
}
