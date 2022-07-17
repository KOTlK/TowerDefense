using UnityEngine;

namespace Game.Weapon
{
    public interface IWeapon
    {
        /// <summary>
        /// Cooldown in ms
        /// </summary>
        int Cooldown { get; }
        void Shoot(Vector3 direction);
    }
}