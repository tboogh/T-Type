using UnityEngine;

namespace Script.Enemy
{
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

        public void SetPosition()
        {
        
        }

        public void Init()
        {
            
        }

        public void SetRotation()
        {
            
        }
    }
}