using Assets.Script.State;
using UnityEngine;

public class PlayerContext : Context, IPlayerContext
{
    private PlayerStateFactory _factory;

    public PlayerContext(BasicInput input, Thruster thruster, Cannon cannon, Transform transform, Rigidbody rigidbody)
    {
        _factory = new PlayerStateFactory(this, input, thruster, cannon, transform, rigidbody);
    }

    public void Update(float deltatime)
    {
        var playerState = CurrentState as IPlayerState;
        if (playerState == null) 
            return;
        
        playerState.Update(deltatime);
    }
    
    public void SetPlayingState()
    {
        SetState(_factory.CreatePlayingState());
    }

    public void SetDeadState()
    {
        SetState(_factory.CreateDeadState());
    }
}