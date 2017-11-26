using UnityEngine;

public class BasicInput : IInput, IFrameUpdate
{
    public bool MoveUp { get; private set; }

    public bool MoveDown { get; private set; }

    public bool MoveForward { get; private set; }

    public bool MoveBack { get; private set; }

    public bool Fire { get; private set; }

    public bool Charge { get; private set; }

    public bool Release { get; private set; }

    private int _fireFrame;

    public void FrameUpdate(float deltaTime)
    {
        var up = Input.GetKey(KeyCode.UpArrow);
        var down = Input.GetKey(KeyCode.DownArrow);
        var forward = Input.GetKey(KeyCode.RightArrow);
        var back = Input.GetKey(KeyCode.LeftArrow);
        var fire = Input.GetKeyUp(KeyCode.Space);
        var charge = Input.GetKeyDown(KeyCode.Space);
        var release = Input.GetKeyDown(KeyCode.R);

        MoveUp = up && !down;
        MoveDown = down && !up;
        MoveForward = forward && !back;
        MoveBack = back && !forward;
        Fire = fire;
        Charge = charge;
        Release = release;
    }

    public override string ToString()
    {
        return string.Format("[BasicInput: MoveUp={0}, MoveDown={1}, MoveForward={2}, MoveBack={3}, Fire={4}, Charge={5}, Release={6}]", MoveUp, MoveDown, MoveForward, MoveBack, Fire, Charge, Release);
    }
}