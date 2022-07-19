using System;

namespace Game.Hp
{
    public interface IMutable<out T>
    {
        event Action<T> Changed;
    }
}