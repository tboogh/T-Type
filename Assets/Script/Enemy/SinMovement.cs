using System;
using UnityEngine;

namespace Script.Enemy
{
    public class SinMovement : MonoBehaviour, IMovement
    {
        private float _y;
        private Rigidbody _rigidbody;
        private float _t;
        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
            _y = _rigidbody.position.y;
        }
        
        public void FrameUpdate(float deltaTime)
        {
            _t += deltaTime;
            _rigidbody.rotation = SetRotation();
            var vel = _rigidbody.rotation * Vector3.back * deltaTime * 100f;
            Debug.DrawRay(_rigidbody.position, vel, Color.red);
            _rigidbody.velocity = vel;
        }

        private Quaternion SetRotation()
        {
            var f = Mathf.Sin(_t) * -45;
            Debug.Log(string.Format("{0} {1}", _t, f));
            return Quaternion.Euler(f, 0, 0);
        }

        public void SetPosition()
        {
            transform.position = SetStartPosition(transform.position);
            transform.rotation = SetStartRotation(transform.position);
        }

        private Quaternion SetStartRotation(Vector3 transformPosition)
        {
            return Quaternion.Euler((CalculateRotation(transformPosition) * Mathf.Rad2Deg), 0, 0);         
        }

        private Vector3 SetStartPosition(Vector3 transformPosition)
        {
            transformPosition.y = CalculateYOffset(transformPosition);
            return transformPosition;
        }

        private float CalculateYOffset(Vector3 position, float frequency = 1f, float amplitude = 0f, float offset = 0f)
        {
            return _y + Mathf.Sin(position.z * frequency)+ offset * amplitude;
        }

        private float CalculateRotation(Vector3 position, float frequency = 1f, float amplitude = 0f, float offset = 0f)
        {
            var value = Mathf.Tan(Mathf.Sin(position.z * frequency)+ offset * amplitude);
            return 0;
        }
        

        public Quaternion GetNextRotation(float frequency = .5f, float amplitude = 1.5f, float offset = 0f)
        {
            var v = _rigidbody .position;
            v.y = _y + Mathf.Sin((v.z + .1f) * frequency)+ offset * amplitude;
            v.z += .1f;
            return Quaternion.LookRotation(v, Vector3.up);
        }
    }
}