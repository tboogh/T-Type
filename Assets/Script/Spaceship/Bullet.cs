using UnityEngine;
using System.Collections;
using System;
using Assets.Script;
using Assets.Script.Spaceship;

public class BulletEventArgs : EventArgs
{
    public IBullet Bullet { get; private set; }
    public BulletEventArgs(IBullet bullet)
    {
        Bullet = bullet;
    }
}

public class Bullet : MonoBehaviour, IBullet
{
    Rigidbody _rigidBody;
    private float _intensity;
    private bool _penetrating;

    public void Fire(Vector3 startPosition, float speed, float intensity, bool penetrating = false)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = startPosition;
        gameObject.transform.localScale = Vector3.one * intensity;
        _rigidBody.AddForce(Vector3.forward * speed);
        _penetrating = penetrating;
    }

    public event EventHandler<BulletEventArgs> BulletRecycle;

    public bool Penetrating
    {
        get { return _penetrating; }
    }
    
    // Use this for initialization
    void Awake()
	{
        _rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
			
	}

    protected virtual void OnBulletRecycle(BulletEventArgs e)
    {
        var handler = BulletRecycle;
        if (handler != null)
            handler(this, e);
    }
    
    public void Recycle()
    {
        _rigidBody.velocity = Vector3.zero;
        gameObject.SetActive(false);
        OnBulletRecycle(new BulletEventArgs(this));
    }

    void OnTriggerEnter(Collider other)
    {    
        if (other.GetComponent<IBulletRecycle>() != null)
        {
            Recycle();
        }

        var destructable = other.GetComponent<IDestructable>();
        if (destructable != null)
        {
            destructable.Damage(_intensity);
            if (!_penetrating)
            {
                Recycle();
            }
        }
    }
}
