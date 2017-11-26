using System;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    IInput _input;
    IWeapon _weapon;
    IThruster _thruster;

    [SerializeField]
    private WeaponData _weaponData;

    [SerializeField]
    private ThrusterData _thrusterData;


	// Use this for initialization
	void Start () {
        _input = new BasicInput();
        _thruster = new Thruster(transform, _thrusterData);
        _weapon = new Cannon(Vector3.forward, _weaponData, new BulletFactory(_weaponData));
	}
	
	// Update is called once per frame
	void Update ()
    {

        var deltaTime = Time.deltaTime;
        UpdateFrame((IFrameUpdate)_input, deltaTime);
        HandleWeaponInput();
        HandleMovementInput();
        UpdateFrame((IFrameUpdate)_thruster, deltaTime);
        UpdateFrame((IFrameUpdate)_weapon, deltaTime);
    }

    private void UpdateFrame(IFrameUpdate frameUpdate, float delteTime)
    {
        frameUpdate.FrameUpdate(delteTime);
    }

    private void HandleMovementInput()
    {
        if (_input.MoveUp)
        {
            _thruster.Up();
        }

        if (_input.MoveDown)
        {
            _thruster.Down();
        }

        if (_input.MoveForward)
        {
            _thruster.Forward(false);
        }

        if (_input.MoveBack)
        {
            _thruster.Back();
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
        _weapon.Charge();
    }

    private void Fire(Vector3 currentPosition)
    {
        _weapon.Fire(currentPosition);
    }
}
