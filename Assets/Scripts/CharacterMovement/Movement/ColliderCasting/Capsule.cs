using System;
using UnityEngine;

namespace CharacterMovement.Movement
{
    [Serializable]
    public class Capsule
    {
        private readonly CapsuleCollider _origin;

        public Capsule(CapsuleCollider origin)
        {
            _origin = origin;
        }

        public float Height => _origin.height - 1;
        public float Radius => _origin.radius;
    }
}