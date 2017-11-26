using UnityEngine;

public interface IInput
{
    bool MoveUp { get; }
    bool MoveDown { get; }
    bool MoveForward { get; }
    bool MoveBack { get; }
    bool Fire { get; }
    bool Charge { get; }
    bool Release { get; }
}