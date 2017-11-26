using UnityEngine;

public class Cannon : IWeapon, IFrameUpdate
{
    float _intensity = 1.0f;
    bool _charging;
    readonly IBulletFactory _bulletFactory;

    public Cannon(Vector3 muzzlePosition, WeaponData weaponData, IBulletFactory bulletFactory)
    {
        _bulletFactory = bulletFactory;
        MuzzlePosition = muzzlePosition;
        WeaponData = weaponData;
    }

    Vector3 MuzzlePosition { get; set; }
    WeaponData WeaponData { get; set; }

    public void Fire(Vector3 currentPosition)
    {
        var bullet = _bulletFactory.CreateBullet();
        bullet.Fire(currentPosition + MuzzlePosition, WeaponData.BulletSpeed, _intensity);
        _intensity = 1f;
        _charging = false;

    }

    public void Charge()
    {
        _charging = true;
    }

    public void FrameUpdate(float deltaTime)
    {
        if (_charging)
        {
            _intensity = Mathf.Clamp(_intensity + WeaponData.ChargeRate * deltaTime, 1f, WeaponData.MaxCharge);
        }
    }
}
