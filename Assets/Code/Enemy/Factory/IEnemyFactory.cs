using UnityEngine;

public interface IEnemyFactory
{
    EnemyMeleeData CreateEnemy(EnemyMeleeDataConfig data);
}

