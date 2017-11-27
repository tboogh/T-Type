using System;
using UnityEngine;

public class CannonChargeEventArgs : EventArgs
{
    public float Intensity { get; private set; }
    public float MaxValue { get; private set; }

    public CannonChargeEventArgs(float intensity, float maxValue)
    {
        Intensity = intensity;
        MaxValue = maxValue;
    }

    public override string ToString()
    {
        return String.Format("Intesity: {0} MaxValue: {1}", Intensity, MaxValue);
    }
}

public interface ICannon
{
    void Fire(Vector3 currentPosition);
    void Charge();
    event EventHandler<CannonChargeEventArgs> ChargevalueChanged;
}