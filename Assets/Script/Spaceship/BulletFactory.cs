using System;
using System.Collections.Generic;
using System.Linq;
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

        if (bullet == null)
        {
            Debug.Log("CreateNew");
            var bulletGameObject = UnityEngine.Object.Instantiate(_weaponData.BulletPrefab, Vector3.zero, Quaternion.identity);
            bullet = bulletGameObject.GetComponent<IBullet>();
            bullet.Barrierhit += Bullet_Barrierhit;
        }
        Debug.Log("Get");
        return bullet;
    }

    void Bullet_Barrierhit(object sender, EventArgs e)
    {
        Debug.Log("Hit");
        var bullet = sender as IBullet;
        if (bullet != null){
            bullet.Recycle();
            _bullets.Enqueue(bullet);
        }
    }
}
