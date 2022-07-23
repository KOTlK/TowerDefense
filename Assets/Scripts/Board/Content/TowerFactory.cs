using Game.Hp;
using Game.Weapon;
using UnityEngine;
using Utils;

namespace Game.Board.Content
{
    public class TowerFactory : IFactory<Tower>
    {
        private readonly IHealthView _healthView;
        private readonly IObjectPool<IProjectile> _pool;


        public TowerFactory(IHealthView healthView, IObjectPool<IProjectile> pool)
        {
            _healthView = healthView;
            _pool = pool;
        }

        private const string Path = "Prefabs/Tower";
        
        public Tower Instantiate()
        {
            var prefab = Resources.Load<Tower>(Path);
            var obj = Object.Instantiate(prefab);
            obj.Init(_healthView, _pool);
            return obj;
        }
    }
}