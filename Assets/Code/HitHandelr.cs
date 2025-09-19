using UnityEngine;

public class HitHandelr : MonoBehaviour
{
    private IHitEnemies _hitEnemys;

    private void Start()
    {
        IHitEnemies[] hitEnemies = FindObjectsByType<TESTControllers>(FindObjectsSortMode.None);
    }

    public void ApplyHitFromEnemy(int damage, IDamageable damageable,GameObject source)
    {
        _hitEnemys.ApplyHit(damageable, damage, source);
    }

    public void ApplyCharacterHitFromEnemy(IDamageable damageable)
    {
        //_hitEnemys.ApplyHit(damageable);
    }
}
