using UnityEngine;
using Utils;

namespace Game.Weapon
{
    public class PlasmaGun : IWeapon
    {
        private readonly IObjectPool<IProjectile> _pool;
        private readonly Transform _origin;

        public PlasmaGun(IObjectPool<IProjectile> pool, Transform origin, int cooldown)
        {
            _pool = pool;
            _origin = origin;
            Cooldown = cooldown;
        }

        public void Shoot(Vector3 direction)
        {
            var projectile = _pool.Pop();
            projectile.Hit += () => Release(projectile);
            projectile.Shoot(_origin.position, direction);
        }

        private void Release(IProjectile projectile)
        {
            _pool.Release(projectile);
            projectile.Hit -= () => Release(projectile);
        }
        
        public int Cooldown { get; }
    }
}