using UnityEngine;

namespace Script.Enemy
{
    public class SinMovement : MonoBehaviour, IMovement
    {
        private float _y;
        
        void Start()
        {
            Init();
        }

        public void Init()
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

            var v = transform.position;
            var vector = transform.position;
            vector.y = _y + Mathf.Sin(vector.z * frequency)+ offset * amplitude;
            transform.position = vector;
            
            
            v.y = _y + Mathf.Sin((v.z + .1f) * frequency)+ offset * amplitude;
            v.z += .1f;
            transform.LookAt(v);
        }
    }
}