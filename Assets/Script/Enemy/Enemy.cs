using System.Collections;
using System.Collections.Generic;
using Assets.Script;
using Assets.Script.Spaceship;
using UnityEngine;

public interface IDestructable
{
	void Damage(float amount);
}

public class Enemy : MonoBehaviour, IDestructable
{
    private IMovement _movement;

	// Use this for initialization
	void Start ()
	{
		_movement = GetComponent<IMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		_movement.FrameUpdate(Time.deltaTime);
	}

	public void Damage(float amount)
	{
		Recycle();
	}
	
	void OnTriggerEnter(Collider other)
	{    
		if (other.GetComponent<IEnemyRecycle>() != null)
		{
			Recycle();
		}

	}

	private void Recycle()
	{
		Destroy(gameObject);
	}
}
