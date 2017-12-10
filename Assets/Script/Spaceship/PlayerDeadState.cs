using Assets.Script.State;
using UnityEngine;

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
        
        Debug.Log("PlayerDeadState.OnEnable()");
        _rigidbody.useGravity = true;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(0, -5f, 5f);
        _rigidbody.AddTorque(35, 5, 45);
    }

    public void OnDisable()
    {
        _rigidbody.useGravity = false;
    }
}