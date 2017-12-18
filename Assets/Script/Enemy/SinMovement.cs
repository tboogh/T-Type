using System;
using UnityEngine;

namespace Script.Enemy
{
    public class SinMovement : MonoBehaviour, IMovement
    {
        private float _y;
        private Rigidbody _rigidbody;
        private float _t;
        private float _frequency = .5f;

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
            var position = transform.position;
            position.z -= 10 * deltaTime;
            transform.position = position;
            SetPosition();
            SetRotation();
        }

        public void SetRotation()
        {
            var rotation = -(Mathf.Cos(transform.position.z * _frequency));
            var q = Quaternion.Euler(Mathf.Rad2Deg * rotation, 0, 0);
            transform.localRotation = q;
        }

        public void SetPosition()
        {
            var position = transform.localPosition;
            position.y = Mathf.Sin(transform.position.z * _frequency);
            transform.localPosition = position;
        }
    }
}