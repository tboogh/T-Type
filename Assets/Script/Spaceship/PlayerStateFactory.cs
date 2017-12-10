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