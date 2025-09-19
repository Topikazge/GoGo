using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    public EnemyMeleeData CreateEnemy(EnemyMeleeDataConfig data)
    {
        GameObject enemyObject = Object.Instantiate(data.Prefub);
        EnemyMeleeView enemyView = enemyObject.GetComponent<EnemyMeleeView>();
        SpriteRenderer spriteRenderer = enemyObject.GetComponent<SpriteRenderer>();

        enemyView.Init(new EnemyMeleeData(data.MaxHealth, enemyObject, data, enemyView), spriteRenderer);
        spriteRenderer.sprite = data.Sprite;
        enemyObject.GetComponent<Animator>().runtimeAnimatorController = data.AnimatorController;
        return enemyView.Data;
    }
}
