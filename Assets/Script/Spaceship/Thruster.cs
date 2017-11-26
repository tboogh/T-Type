using UnityEngine;

public class Thruster : IThruster, IFrameUpdate
{
    private Vector3 _thruser;
    private Transform _transform;

    public ThrusterData _thrusterData { get; private set; }

    public Thruster(Transform transform, ThrusterData _thrusterData)
    {
        this._thrusterData = _thrusterData;
        _transform = transform;
        _thruser = Vector3.zero;
    }

    public void Back()
    {
        _thruser.z = -_thrusterData.BackwardsSpeed;
    }

    public void Down()
    {
        _thruser.y = -_thrusterData.DownwardSpeed;
    }

    public void Forward(bool afterBurner)
    {
        _thruser.z = _thrusterData.ForwardSpeed;
    }

    public void Up()
    {
        _thruser.y = _thrusterData.UpwardSpeed;
    }

    public void FrameUpdate(float deltaTime)
    {
        _transform.Translate(_thruser * deltaTime);
        _thruser = Vector3.zero;
    }
}
