using System;

namespace Game.Hp
{
    public interface IHealth : IMutable<float>, IDrawable<IHealthView>
    {
        void Restore(float amount);
        void Lose(float amount);
    }
}