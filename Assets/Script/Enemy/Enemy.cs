using System.Collections;
using System.Collections.Generic;
using Assets.Script.Spaceship;
using UnityEngine;

public class Enemy : MonoBehaviour, IBulletTrigger
{
    private IMovement _movement;

	// Use this for initialization
	void Start ()
	{
	    _movement = new BasicMovement(transform);
	}
	
	// Update is called once per frame
	void Update () {
		_movement.FrameUpdate(Time.deltaTime);
	}

    public void Trigger()
    {
        Destroy(gameObject);
    }
}
