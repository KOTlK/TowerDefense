using System.Collections.Generic;
using Utils;

namespace Game.Weapon
{
    public class PlasmaPool : IObjectPool<IProjectile>
    {
        private readonly Stack<IProjectile> _stack = new();
        private readonly IFactory<IProjectile> _factory;

        public PlasmaPool(IFactory<Plasma> factory)
        {
            _factory = factory;
        }

        public IProjectile Pop()
        {
            if (_stack.Count == 0) return _factory.Instantiate();

            return _stack.Pop();
        }

        public void Release(IProjectile obj)
        {
            _stack.Push(obj);
        }
        
    }
}