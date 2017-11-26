using System;
using UnityEngine;

public interface IBullet
{
    void Fire(Vector3 startPosition, float speed, float intensity);
    event EventHandler Barrierhit;
    void Recycle();
}