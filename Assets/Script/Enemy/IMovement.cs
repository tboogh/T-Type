using System.Security.Cryptography;

public interface IMovement : IFrameUpdate
{
    void SetPosition();
    void Init();
}