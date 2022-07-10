using UnityEngine;

namespace Utils
{
    public interface IFactory<out T>
    {
        T Instantiate();
    }

    public interface IPrefabFactory<out T> : IFactory<T>
        where T : Object
    {
        
    }
}