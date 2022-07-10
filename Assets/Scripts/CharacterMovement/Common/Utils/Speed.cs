using System;
using UnityEngine;

namespace CharacterMovement
{
    //Horrible mutable shit. Should not exist, but.
    [Serializable]
    public sealed class Speed : ISpeed
    {
        public Speed(float start)
        {
            Current = start;
        }
        
        [field: SerializeField] public float Current { get; private set; }

        public void Change(float newSpeed)
        {
            Current = newSpeed;
        }
    }
}