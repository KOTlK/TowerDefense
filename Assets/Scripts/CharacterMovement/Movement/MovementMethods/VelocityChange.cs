using System.Linq;
using UnityEngine;

namespace CharacterMovement.Movement
{
    public class VelocityChange : IMovement
    {
        private readonly IOverlapCollider _cast;
        private readonly ISpeed _speed;
        private readonly Rigidbody _rigidbody;

        /// <summary>
        /// Moves body, changing it's velocity
        /// </summary>
        /// <param name="cast">Cast method</param>
        /// <param name="speed">Movement speed</param>
        /// <param name="rigidbody">Body</param>
        public VelocityChange(IOverlapCollider cast, ISpeed speed, Rigidbody rigidbody)
        {
            _cast = cast;
            _speed = speed;
            _rigidbody = rigidbody;
        }

        public Vector3 Position => _rigidbody.position;

        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero) return;

            var contacts = _cast.Cast(_rigidbody.position + direction);
            Debug.Log(contacts.Count);
            
            if (contacts == OverlapContacts.Zero)
            {
                ApplyVelocity(Vector3.zero);
                return;
            }

            ApplyVelocity(direction * _speed.Current);
        }

        private void ApplyVelocity(Vector3 value)
        {
            var velocity = _rigidbody.velocity;

            velocity.x = value.x;
            velocity.z = value.z;

            _rigidbody.velocity = velocity;
        }
    }
}