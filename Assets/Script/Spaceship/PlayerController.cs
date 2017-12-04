using System;
using System.Runtime.InteropServices;
using Assets.Script;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDestructable
{
    [SerializeField]
    private WeaponData _weaponData;

    [SerializeField]
    private ThrusterData _thrusterData;

    [SerializeField] 
    private Bounds _movementBounds;

    [SerializeField] 
    private Rigidbody _rigidbody;

    private PlayerContext _context;

    public Bounds MovementBounds
    {
        get { return _movementBounds; }
        set { _movementBounds = value; }
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        var input = new BasicInput();
        var thruster = new Thruster(transform, _thrusterData, _movementBounds);
        var cannon = new Cannon(Vector3.forward, _weaponData, new BulletFactory(_weaponData));
        cannon.ChargevalueChanged += CannonOnChargevalueChanged;
        
        _context = new PlayerContext(input, thruster, cannon, transform, _rigidbody);
        _context.SetPlayingState();
    }

    private void CannonOnChargevalueChanged(object sender, CannonChargeEventArgs cannonChargeEventArgs)
    {
        if (ChargevalueChanged != null) 
            ChargevalueChanged.Invoke(sender, cannonChargeEventArgs);
    }

    // Update is called once per frame
	void Update ()
    {
        _context.Update(Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!(_context.CurrentState is PlayerControlledState))
            return;
        
        _context.SetDeadState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + MovementBounds.center, MovementBounds.size);
        var a = _movementBounds.max + transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(a, 0.1f);
    }

    public void Damage(float amount)
    {
        _rigidbody.isKinematic = false;
    }

    public event EventHandler<CannonChargeEventArgs> ChargevalueChanged;
}
