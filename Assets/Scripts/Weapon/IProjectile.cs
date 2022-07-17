using System;
using UnityEngine;

namespace Game.Weapon
{
    public interface IProjectile
    {
        event Action Hit;
        void Shoot(Vector3 startPosition, Vector3 direction);
    }
}