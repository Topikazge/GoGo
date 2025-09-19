using UnityEngine;

public class EnemyRangedView : EnemyView
{
    private EnemyRangedData _data;

    public override int Damage => throw new System.NotImplementedException();

    public void Init(EnemyRangedData data)
    {
        _data = data;
    }

    public override void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }
}
