using System;
using UnityEngine;

namespace Assets.Script.Spaceship
{
    public interface IBullet
    {
        void Fire(Vector3 startPosition, float speed, float intensity, bool penetrating = false);
        event EventHandler<BulletEventArgs> TriggerHit;
        void Recycle();
    }
}