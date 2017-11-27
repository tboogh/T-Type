using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "CameraRigData", menuName = "TType/CameraRigData", order = 1)]
public class CameraRigData : ScriptableObject
{
    [SerializeField]
    private float _movementSpeed = 1.0f;

    public float MovementSpeed 
    {
        get
        {
            return _movementSpeed;
        }
    }
}
