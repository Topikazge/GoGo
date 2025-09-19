using UnityEngine;

public class DamageSystem
{
    public static void ApplyDamage(IDamageable target, int amount, GameObject source)
    {
        target.TakeDamage(amount);
    }
}
