using System;
using UnityEngine;

namespace Game.Hp
{
    public class Health : IHealth
    {
        public event Action<float> Changed;
        
        private readonly float _max;
        
        private const float Min = 0f;

        private float _current;

        public Health(float max)
        {
            if (max < 0) throw new ArgumentException($"{nameof(max)} can not be less than zero", nameof(max));
            _max = max;
            _current = _max;
        }


        public void Restore(float amount)
        {
            SetCurrent(Mathf.Clamp(_current + amount, Min, _max));
        }

        public void Lose(float amount)
        {
            SetCurrent(Mathf.Clamp(_current - amount, Min, _max));
        }

        private void SetCurrent(float amount)
        {
            if (amount <= 0)
            {
                _current = 0;
                Changed?.Invoke(0);
                return;
            }

            _current = amount;
            Changed?.Invoke(amount);
        }

        public void Draw(IHealthView view)
        {
            view.UpdateView(_current);
        }
    }
}