﻿using UnityEngine;

public interface IWeapon
{
    void Fire(Vector3 currentPosition);
    void Charge();
}