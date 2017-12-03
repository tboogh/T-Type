using UnityEngine;

public class Thruster : IThruster, IFrameUpdate
{
    private Vector3 _thruser;
    private Transform _transform;
    private Bounds _movementBounds { get; set; }
    public ThrusterData _thrusterData { get; private set; }

    public Thruster(Transform transform, ThrusterData _thrusterData, Bounds movementBounds)
    {
        this._thrusterData = _thrusterData;
        _transform = transform;
        _thruser = Vector3.zero;
        _movementBounds = movementBounds;
    }

    public void Back()
    {
        if (!CanMoveLeft())
            return;
        
        _thruser.z = -_thrusterData.BackwardsSpeed;
    }

    public void Down()
    {
        if (!CanMoveDown())
            return;
        
        _thruser.y = -_thrusterData.DownwardSpeed;
    }

    public void Forward(bool afterBurner)
    {
        if (!CanMoveForward())
            return;
        
        _thruser.z = _thrusterData.ForwardSpeed;
    }

    public void Up()
    {
        if (!CanMoveUp())
            return;
        
        _thruser.y = _thrusterData.UpwardSpeed;
    }

    public void FrameUpdate(float deltaTime)
    {
        _transform.Translate(_thruser * deltaTime);
        _thruser = Vector3.zero;
    }
    
    private bool CanMoveDown()
    {
        var minViewPort = GetMinViewPort();
        return minViewPort.y >= 0.05;
    }
    
    private bool CanMoveUp()
    {
        var maxViewPort = GetMaxViewPort();
        return maxViewPort.y <= 0.95;
    }
    
    private bool CanMoveLeft()
    {
        var minViewPort = GetMinViewPort();
        return minViewPort.x >= 0.05;
    }

    private bool CanMoveForward()
    {
        var maxViewPort = GetMaxViewPort();
        return maxViewPort.x <= 0.95;
    }
    
    private Vector3 GetMinViewPort()
    {
        return PointInViewPort(_movementBounds.min + _transform.position);
    }    

    private Vector3 GetMaxViewPort()
    {
        return PointInViewPort(_movementBounds.max + _transform.position);
    }
    
    private Vector3 PointInViewPort(Vector3 point)
    {
        var viewPortPosition = Camera.main.WorldToViewportPoint(point);
        return viewPortPosition;
    }
}
