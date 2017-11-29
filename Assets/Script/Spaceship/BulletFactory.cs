using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Script.Spaceship;
using UnityEngine;


public class BulletFactory : IBulletFactory
{
    readonly WeaponData _weaponData;

    Queue<IBullet> _bullets = new Queue<IBullet>();

    public BulletFactory(WeaponData weaponData)
    {
        _weaponData = weaponData;
    }

    public IBullet CreateBullet()
    {
        return GetOrCreateBullet();
    }

    private IBullet GetOrCreateBullet()
    {
        IBullet bullet = null;
        try
        {
            bullet = _bullets.Dequeue();
        }
        catch (Exception)
        {
            // ignore
        }

        if (bullet != null)
            return bullet;

        var bulletGameObject = UnityEngine.Object.Instantiate(_weaponData.BulletPrefab, Vector3.zero, Quaternion.identity);
        bullet = bulletGameObject.GetComponent<IBullet>();
        bullet.TriggerHit += Bullet_Barrierhit;

        return bullet;
    }

    void Bullet_Barrierhit(object sender, BulletEventArgs bulletEventArgs)
    {
        _bullets.Enqueue(bulletEventArgs.Bullet);
    }
}
