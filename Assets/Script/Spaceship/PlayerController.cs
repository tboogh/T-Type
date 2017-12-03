using System.Runtime.InteropServices;
using Assets.Script;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IInput _input;
    private IThruster Thruster { get; set; }
    
    public ICannon Cannon { get; private set; }

    [SerializeField]
    private WeaponData _weaponData;

    [SerializeField]
    private ThrusterData _thrusterData;

    [SerializeField] 
    private Bounds _movementBounds;

    public Bounds MovementBounds
    {
        get { return _movementBounds; }
        set { _movementBounds = value; }
    }

    void Awake()
    {
        _input = new BasicInput();
        Thruster = new Thruster(transform, _thrusterData);
        Cannon = new Cannon(Vector3.forward, _weaponData, new BulletFactory(_weaponData));
    }

    void Start()
    {
        
    }

    // Use this for initialization

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
        if (_input.MoveUp && !AtTopEdge())
        {
            Thruster.Up();
        }

        if (_input.MoveDown && !AtBottomEdge())
        {
            Thruster.Down();
        }

        if (_input.MoveForward && !AtRightEdge())
        {
            Thruster.Forward(false);
        }

        if (_input.MoveBack && !AtLeftEdge())
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
    
    private bool AtBottomEdge()
    {
        var minViewPort = GetMinViewPort();
        return minViewPort.y <= 0.05;
    }
    
    private bool AtTopEdge()
    {
        var maxViewPort = GetMaxViewPort();
        return maxViewPort.y >= 0.95;
    }
    
    private bool AtLeftEdge()
    {
        var minViewPort = GetMinViewPort();
        return minViewPort.x <= 0.05;
    }

    private bool AtRightEdge()
    {
        var maxViewPort = GetMaxViewPort();
        return maxViewPort.x >= 0.95;
    }
    
    private Vector3 GetMinViewPort()
    {
        return PointInViewPort(_movementBounds.min + transform.position);
    }    

    private Vector3 GetMaxViewPort()
    {
        return PointInViewPort(_movementBounds.max + transform.position);
    }
    
    private Vector3 PointInViewPort(Vector3 point)
    {
        var viewPortPosition = Camera.main.WorldToViewportPoint(point);
        return viewPortPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + MovementBounds.center, MovementBounds.size);
        var a = _movementBounds.max + transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(a, 0.1f);
    }
}
