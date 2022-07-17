using UnityEngine;

namespace CharacterMovement.Movement
{
    public class AlongSurface : IMovement
    {
        private readonly Rigidbody _origin;
        private readonly IRaycast _raycast;
        private readonly MovementAngle _angleValidator;
        private readonly ISpeed _speed;

        private Vector3 _normal;

        public AlongSurface(Rigidbody body, ISpeed speed, IRaycast castMethod, MovementAngle angleValidator)
        {
            _angleValidator = angleValidator;
            _origin = body;
            _speed = speed;
            _raycast = castMethod;
        }
        
        public Vector3 Position { get; private set; }

        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero) return;

            var contacts = _raycast.Cast(_origin.position + direction * _speed.Current * Time.deltaTime, Vector3.down);
            var normal = contacts.Normal;
            
            if (contacts == Rayhit.None)
            {
                normal = _normal;
            }
            else
            {
                _normal = normal;
                Position = contacts.Point;
            }
            

            if (_angleValidator.IsValid(direction, normal) == false) return;

            var movement = TargetDirection(direction, normal) * _speed.Current * Time.deltaTime;
            _origin.MovePosition(_origin.position + movement);

        }
        
        private Vector3 TargetDirection(Vector3 direction, Vector3 normal)
        {
            return direction - Vector3.Dot(direction, normal) * normal;
        }
    }
}