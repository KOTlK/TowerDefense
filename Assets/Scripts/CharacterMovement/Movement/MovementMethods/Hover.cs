using System;
using UnityEngine;

namespace CharacterMovement.Movement
{
    public class Hover : IMovement
    {
        private readonly Rigidbody _origin;
        private readonly ISpeed _speed;
        private readonly float _height;
        private readonly float _damping;
        private readonly float _speedDecay;


        /// <summary>
        /// Hover body over the ground
        /// </summary>
        /// <param name="origin">Rigidbody component</param>
        /// <param name="speed">Max speed</param>
        /// <param name="height">Height above ground</param>
        /// <param name="damping">The lower this value the higher wavering of height</param>
        /// <param name="speedDecay">The lower this value the slower speed will decay</param>
        public Hover(Rigidbody origin, ISpeed speed, float height, float damping, float speedDecay)
        {
            _origin = origin;
            _speed = speed;
            _height = height;
            _damping = damping;
            _speedDecay = speedDecay;
        }

        public Vector3 Position => _origin.position;

        public void Move(Vector3 direction)
        {
            var results = new RaycastHit[1];

            Physics.RaycastNonAlloc(_origin.position, -Vector3.up, results, Mathf.Infinity);
            
            AddForce(direction, _origin.position.y - results[0].point.y);
        }


        private void AddForce(Vector3 direction, float distanceToGround)
        {
            var xSpeed = _speed.Current;
            var zSpeed = _speed.Current;

            if (direction == Vector3.zero) SlowDown(Axis.Both);
            else
            {
                if (direction.x == 0) SlowDown(Axis.X);
                if (direction.z == 0) SlowDown(Axis.Z);
                
                if (_origin.velocity.x != 0)
                {
                    if (_origin.velocity.x >= _speed.Current && direction.x > 0) xSpeed = 0;
                    if (_origin.velocity.x <= -_speed.Current && direction.x < 0) xSpeed = 0;
                }

                if (_origin.velocity.z != 0)
                {
                    if (_origin.velocity.z >= _speed.Current && direction.z > 0) zSpeed = 0;
                    if (_origin.velocity.z <= -_speed.Current && direction.z < 0) zSpeed = 0;
                }
            }
            
            
            _origin.AddForce(
                direction.x * xSpeed,
                _height / (distanceToGround + _origin.velocity.y * _damping) * -Physics.gravity.y,
                direction.z * zSpeed,
                ForceMode.Acceleration);
        }

        private void SlowDown(Axis axis)
        {
            var velocity = _origin.velocity;
            switch (axis)
            {
                case Axis.Both:
                    _origin.velocity = new Vector3(
                        Mathf.Lerp(velocity.x, 0, _speedDecay),
                        velocity.y,
                        Mathf.Lerp(velocity.z, 0, _speedDecay));
                    return;
                case Axis.X:
                    _origin.velocity = new Vector3(
                        Mathf.Lerp(velocity.x, 0, _speedDecay),
                        velocity.y,
                        velocity.z);
                    return;
                case Axis.Z:
                    _origin.velocity = new Vector3(
                        velocity.x,
                        velocity.y,
                        Mathf.Lerp(velocity.z, 0, _speedDecay));
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
            }
            
            
        }

        private enum Axis
        {
            X,
            Z,
            Both
        }
    }
}