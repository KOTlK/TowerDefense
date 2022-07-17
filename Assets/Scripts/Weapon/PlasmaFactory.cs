using UnityEngine;
using Utils;

namespace Game.Weapon
{
    public class PlasmaFactory : IFactory<Plasma>
    {
        private readonly Transform _parent;

        public PlasmaFactory(Transform parent)
        {
            _parent = parent;
        }

        private const string Path = "Prefabs/Plasma";
        public Plasma Instantiate()
        {
            var prefab = Resources.Load<Plasma>(Path);
            return Object.Instantiate(prefab, _parent);
        }
    }
}