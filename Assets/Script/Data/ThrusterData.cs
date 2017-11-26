using UnityEngine;

[CreateAssetMenu(fileName = "ThrusterData", menuName = "TType/ThrusterData", order = 1)]
public class ThrusterData : ScriptableObject
{
    [SerializeField]
    private float _upwardSpeed = 1f;
    [SerializeField]
    private float _downwardSpeed = 1f;
    [SerializeField]
    private float _forwardSpeed = 1f;
    [SerializeField]
    private float _backwardsSpeed = 1f;

    public float UpwardSpeed
    {
        get
        {
            return _upwardSpeed;
        }
    }

    public float DownwardSpeed
    {
        get
        {
            return _downwardSpeed;
        }
    }

    public float ForwardSpeed
    {
        get
        {
            return _forwardSpeed;
        }
    }

    public float BackwardsSpeed
    {
        get
        {
            return _backwardsSpeed;
        }
    }
}
