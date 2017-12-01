using UnityEngine;
using System.Collections;
using System;
using Assets.Script.Spaceship;

public class BulletEventArgs : EventArgs
{
    public IEventTrigger TriggerHit { get; private set; }
    public IBullet Bullet { get; private set; }
    public BulletEventArgs(IBullet bullet, IEventTrigger triggerHit)
    {
        TriggerHit = triggerHit;
        Bullet = bullet;
    }
}

public class Bullet : MonoBehaviour, IBullet
{
    Rigidbody _rigidBody;
    private float _intensity;
    private bool _penetrating;
    public event EventHandler<BulletEventArgs> TriggerHit;

    public void Fire(Vector3 startPosition, float speed, float intensity, bool penetrating = false)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = startPosition;
        gameObject.transform.localScale = Vector3.one * intensity;
        _rigidBody.AddForce(Vector3.forward * speed);
        _penetrating = penetrating;
    }

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

    private void OnTriggerEnter(Collider other)
    {
        var eventTrigger = other.GetComponent<IEventTrigger>();
        if (eventTrigger == null) 
            return;
        eventTrigger.Trigger();
        
        if (!_penetrating)
        {
            Recycle();
            OnTriggerHit(new BulletEventArgs(this, eventTrigger));
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
