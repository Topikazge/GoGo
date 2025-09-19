
using UnityEngine;

public interface IHitEnemies
{
    void ApplyHit(IDamageable target, int amount, GameObject source);
}

