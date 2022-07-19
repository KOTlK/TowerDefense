using UnityEngine;
using Utils;

namespace Game.Hp.View
{
    public class HpView : IFactory<SimpleHpView>
    {
        private const string Path = "UI/TowerHp";
        public SimpleHpView Instantiate()
        {
            var prefab = Resources.Load<SimpleHpView>(Path);
            return Object.Instantiate(prefab);
        }
    }
}