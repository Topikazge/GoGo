using UnityEngine;

public class EnemyMeleeData : EnemyDataBase
{
    private EnemyMeleeView _enemyMeleeView;
    public EnemyMeleeData(int health, GameObject gameobject, EnemyDataConfigBase enemyDataConfigBase, EnemyMeleeView enemyMeleeView) : base(health, gameobject, enemyDataConfigBase)
    {
        EnemyMeleeView = enemyMeleeView;
    }

    public EnemyMeleeView EnemyMeleeView { get => _enemyMeleeView; set => _enemyMeleeView = value; }
}
