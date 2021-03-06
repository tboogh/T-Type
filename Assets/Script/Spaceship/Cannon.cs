using System;
using UnityEngine;

public class Cannon : ICannon, IFrameUpdate
{
    float _intensity = 1.0f;
    bool _charging;
    readonly IBulletFactory _bulletFactory;

    public event EventHandler<CannonChargeEventArgs> ChargevalueChanged;

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
        bullet.Fire(currentPosition + MuzzlePosition, WeaponData.BulletSpeed, _intensity, _intensity >= WeaponData.MaxCharge);
        _intensity = 1f;
        _charging = false;
        OnChargevalueChanged(_intensity, WeaponData.MaxCharge);
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
            OnChargevalueChanged(_intensity, WeaponData.MaxCharge);
        }
    }

    protected virtual void OnChargevalueChanged(float intensity, float maxCharge)
    {
        var handler = ChargevalueChanged;
        if (handler != null) handler(this, new CannonChargeEventArgs(intensity, maxCharge));
    }
}
