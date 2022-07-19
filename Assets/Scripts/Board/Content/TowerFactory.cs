using Game.Hp;
using UnityEngine;
using Utils;

namespace Game.Board.Content
{
    public class TowerFactory : IFactory<Tower>
    {
        private readonly IHealthView _healthView;

        public TowerFactory(IHealthView healthView)
        {
            _healthView = healthView;
        }

        private const string Path = "Prefabs/Tower";
        
        public Tower Instantiate()
        {
            var prefab = Resources.Load<Tower>(Path);
            var obj = Object.Instantiate(prefab);
            obj.Init(_healthView);
            return obj;
        }
    }
}