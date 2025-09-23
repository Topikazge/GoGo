using System.Collections.Generic;
using UnityEngine;


public class ProjectileGun
{
    [SerializeField] private FlyingProjectile _flyingProjectile;
    private WeaponCharacterController _weaponCharacterController;
    private ObjectPool<FlyingProjectile> _projectilePool;
    private float lastShotTime = 0f;
    private float attackCooldown = 0.5f;

    public void Initialize(WeaponCharacterController weaponCharacterController)
    {
        _projectilePool = new ObjectPool<FlyingProjectile>();
        _weaponCharacterController = weaponCharacterController;
    }

    private FlyingProjectile CreateProjectile()
    {
        FlyingProjectile projectile = GameObject.Instantiate(_flyingProjectile, _weaponCharacterController.transform.position, Quaternion.identity);
        projectile.Intialization(this);
        return projectile;
    }

    private FlyingProjectile GetProjectile()
    {
        if (_projectilePool.IsNotEmpty())
        {
            return _projectilePool.GetObjectOrNull();
        }
        else
        {
            return CreateProjectile();
        }
    }

    public void ProjectileIsDeastroy(FlyingProjectile projectile)
    {
        _projectilePool.ReturnInPool(projectile);
    }

    public void Shot()
    {
        if (Time.time < lastShotTime + attackCooldown) return;
        lastShotTime = Time.time;
        FlyingProjectile projectile = GetProjectile();
        projectile.Begin(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)),_weaponCharacterController.transform.position);
    }
}