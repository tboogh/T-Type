using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour, IBullet
{
    Rigidbody _rigidBody;

    public event EventHandler Barrierhit;

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
        var barrier = other.GetComponent<BulletBarrier>();
        if (barrier != null){
            OnBarrierhit(EventArgs.Empty);
        }
    }

    protected virtual void OnBarrierhit(EventArgs e)
    {
        var handler = Barrierhit;
        if (handler != null)
            handler(this, e);
    }

    public void Recycle()
    {
        Debug.Log("Recycle");
        _rigidBody.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
