using UnityEngine;
using System.Collections;
using System;
using Assets.Script.Spaceship;

public class BulletEventArgs : EventArgs
{
    public IBulletTrigger TriggerHit { get; private set; }
    public IBullet Bullet { get; private set; }
    public BulletEventArgs(IBullet bullet, IBulletTrigger triggerHit)
    {
        TriggerHit = triggerHit;
        Bullet = bullet;
    }
}

public class Bullet : MonoBehaviour, IBullet
{
    Rigidbody _rigidBody;

    public event EventHandler<BulletEventArgs> TriggerHit;

    public void Fire(Vector3 startPosition, float speed, float intensity)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = startPosition;
        gameObject.transform.localScale = Vector3.one * intensity;
        _rigidBody.AddForce(Vector3.forward * speed);
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

    private void OnTriggerEnter(Collider other)
    {
        var bulletTrigger = other.GetComponent<IBulletTrigger>();
        if (bulletTrigger != null)
        {
            bulletTrigger.Trigger();
            OnTriggerHit(new BulletEventArgs(this, bulletTrigger));
        }
    }

    protected virtual void OnTriggerHit(BulletEventArgs e)
    {
        var handler = TriggerHit;
        if (handler != null)
            handler(this, e);
    }

    public void Recycle()
    {
        _rigidBody.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
