using System;
using UnityEngine;

namespace Assets.Script.Spaceship
{
    public interface IBullet
    {
        void Fire(Vector3 startPosition, float speed, float intensity);
        event EventHandler<BulletEventArgs> TriggerHit;
        void Recycle();
    }
}