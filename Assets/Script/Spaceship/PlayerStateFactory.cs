using Assets.Script.State;
using UnityEngine;

public class PlayerStateFactory
{
    private readonly IPlayerContext _context;
    private readonly BasicInput _input;
    private readonly Thruster _thruster;
    private readonly Cannon _cannon;
    private readonly Transform _transform;
    private readonly Rigidbody _rigidbody;

    public PlayerStateFactory(IPlayerContext context, BasicInput input, Thruster thruster, Cannon cannon, Transform transform, Rigidbody rigidbody)
    {
        _context = context;
        _input = input;
        _thruster = thruster;
        _cannon = cannon;
        _transform = transform;
        _rigidbody = rigidbody;
    }

    public IPlayerState CreatePlayingState()
    {
        return new PlayerControlledState(_context, _input, _thruster, _cannon, _transform);
    }

    public IPlayerState CreateDeadState()
    {
        return new PlayerDeadState(_context, _rigidbody);
    }
}

public class PlayerDeadState : State, IPlayerState, IEnableAware, IDisableAware
{
    private readonly Rigidbody _rigidbody;

    public PlayerDeadState(IPlayerContext context, Rigidbody rigidbody) : base(context)
    {
        _rigidbody = rigidbody;
    }

    public void Update(float deltaTime)
    {
        
    }

    public void OnEnable()
    {

        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(0, -5f, 5f);
        _rigidbody.AddTorque(35, 5, 45);
    }

    public void OnDisable()
    {
        _rigidbody.isKinematic = true;
    }
}