using Assets.Script.State;
using UnityEngine;

public class PlayerControlledState : State, IPlayerState
{
    private IInput Input { get; set; }
    private IThruster Thruster { get; set; }
    private ICannon Cannon { get; set; }
    private Transform Transform { get; set; }

    public PlayerControlledState(IPlayerContext context, BasicInput input, Thruster thruster, Cannon cannon, Transform transform) : base(context)
    {
        Input = input;
        Thruster = thruster;
        Cannon = cannon;
        Transform = transform;
    }

    public void Update(float deltaTime)
    {
        UpdateFrame((IFrameUpdate)Input, deltaTime);
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
        if (Input.MoveUp)
        {
            Thruster.Up();
        }

        if (Input.MoveDown)
        {
            Thruster.Down();
        }

        if (Input.MoveForward)
        {
            Thruster.Forward(false);
        }

        if (Input.MoveBack)
        {
            Thruster.Back();
        }
    }

    private void HandleWeaponInput()
    {
        if (Input.Fire)
        {
            Fire(Transform.position);
        }

        if (Input.Charge)
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