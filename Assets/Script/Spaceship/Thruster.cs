using UnityEngine;

public class Thruster : IThruster, IFrameUpdate
{
    private Vector3 _thruser;
    private Transform _transform;
    private readonly Rigidbody _rigidbody;
    private Bounds MovementBounds { get; set; }
    private ThrusterData ThrusterData { get; set; }

    public Thruster(Transform transform, ThrusterData thrusterData, Bounds movementBounds, Rigidbody rigidbody)
    {
        ThrusterData = thrusterData;
        _transform = transform;
        _rigidbody = rigidbody;
        _thruser = Vector3.zero;
        MovementBounds = movementBounds;
    }

    public void Back()
    {
        if (!CanMoveLeft())
            return;
        
        _thruser.z = -ThrusterData.BackwardsSpeed;
    }

    public void Down()
    {
        if (!CanMoveDown())
            return;
        
        _thruser.y = -ThrusterData.DownwardSpeed;
    }

    public void Forward(bool afterBurner)
    {
        if (!CanMoveForward())
            return;
        
        _thruser.z = ThrusterData.ForwardSpeed;
    }

    public void Up()
    {
        if (!CanMoveUp())
            return;
        
        _thruser.y = ThrusterData.UpwardSpeed;
    }

    public void FrameUpdate(float deltaTime)
    {
        _rigidbody.velocity = _thruser * deltaTime;
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
        return PointInViewPort(MovementBounds.min + _transform.position);
    }    

    private Vector3 GetMaxViewPort()
    {
        return PointInViewPort(MovementBounds.max + _transform.position);
    }
    
    private Vector3 PointInViewPort(Vector3 point)
    {
        var viewPortPosition = Camera.main.WorldToViewportPoint(point);
        return viewPortPosition;
    }
}
