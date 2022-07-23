using System;

namespace Game.Weapon
{
    public interface IKillable
    {
        event Action Died;
    }
}