using UnityEngine;

namespace Utils
{
    public interface IGameObjectPool<TObject> : IObjectPool<TObject>
    where TObject : Object
    {
    }
}