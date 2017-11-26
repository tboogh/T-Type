using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "WeaponData", menuName = "TType/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private float _maxCharge;

    [SerializeField]
    private float _chargeRate;

    public GameObject BulletPrefab
    {
        get
        {
            return _bulletPrefab;
        }
    }

    public float BulletSpeed
    {
        get
        {
            return _bulletSpeed;
        }
    }

    public float MaxCharge
    {
        get
        {
            return _maxCharge;
        }
    }

    public float ChargeRate
    {
        get
        {
            return _chargeRate;
        }
    }
}