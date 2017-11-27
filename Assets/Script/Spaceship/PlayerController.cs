using System;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    IInput _input;
    public ICannon Cannon { get; private set; }
    private IThruster Thruster { get; set; }

    [SerializeField]
    private WeaponData _weaponData;

    [SerializeField]
    private ThrusterData _thrusterData;


	// Use this for initialization
	void Awake() {
        _input = new BasicInput();
        Thruster = new Thruster(transform, _thrusterData);
        Cannon = new Cannon(Vector3.forward, _weaponData, new BulletFactory(_weaponData));
	}
	
	// Update is called once per frame
	void Update ()
    {

        var deltaTime = Time.deltaTime;
        UpdateFrame((IFrameUpdate)_input, deltaTime);
        HandleWeaponInput();
        HandleMovementInput();
        UpdateFrame((IFrameUpdate)Thruster, deltaTime);
        UpdateFrame((IFrameUpdate)Cannon, deltaTime);
    }

    private void UpdateFrame(IFrameUpdate frameUpdate, float delteTime)
    {
        frameUpdate.FrameUpdate(delteTime);
    }

    private void HandleMovementInput()
    {
        if (_input.MoveUp)
        {
            Thruster.Up();
        }

        if (_input.MoveDown)
        {
            Thruster.Down();
        }

        if (_input.MoveForward)
        {
            Thruster.Forward(false);
        }

        if (_input.MoveBack)
        {
            Thruster.Back();
        }
    }

    private void HandleWeaponInput()
    {
        if (_input.Fire)
        {
            Fire(transform.position);
        }

        if (_input.Charge)
        {
            Charge();
        }
    }

    private void Charge()
    {
        Cannon.Charge();
    }

    private void Fire(Vector3 currentPosition)
    {
        Cannon.Fire(currentPosition);
    }
}
