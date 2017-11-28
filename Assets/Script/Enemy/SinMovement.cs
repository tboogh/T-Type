using UnityEngine;

namespace Script.Enemy
{
    public class SinMovement : MonoBehaviour, IMovement
    {
        private float _y;

        public SinMovement()
        {
        
        }

        void Start()
        {
            _y = transform.position.y;
        }
        
        public void FrameUpdate(float deltaTime)
        {
            var position = transform.position;
            position.z += -5 * deltaTime;
            transform.position = position;
            SetPosition();
        }

        public void SetPosition()
        {
            float frequency = .5f;
            float amplitude = 1.5f;
            float offset = 0f;

            var vector = transform.position;
            vector.y = _y + Mathf.Sin(vector.z * frequency)+ offset * amplitude;
            transform.position = vector;
        }
    }
}