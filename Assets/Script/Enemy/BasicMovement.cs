using UnityEngine;

public class SinMovement : IMovement
{
    private readonly Transform _transform;
    private float _totaltime = 0f;
    public SinMovement(Transform transform)
    {
        _transform = transform;
    }

    public void FrameUpdate(float deltaTime)
    {
        float frequency = 1f;
        float amplitude = 2.5f;
        float offset = 5f;

        _totaltime += deltaTime;
        var vector = Vector3.back * deltaTime * 5;
        vector.y = (Mathf.Sin((_totaltime * frequency) + offset) * deltaTime) * amplitude;
        _transform.Translate(vector);
    }
}

public class BasicMovement : IMovement
{
    private readonly Transform _transform;

    public BasicMovement(Transform transform)
    {
        _transform = transform;
    }

    public void FrameUpdate(float deltaTime)
    {
        _transform.Translate(Vector3.back * deltaTime);
    }
}