using UnityEngine;

namespace CharacterMovement
{
    public sealed class MovementAngle
    {
        private readonly float _minAngle;

        /// <summary>
        /// Minimal angle between movement direction and target normal
        /// </summary>
        /// <param name="minAngle">Minimal angle</param>
        public MovementAngle(float minAngle)
        {
            _minAngle = minAngle;
        }

        /// <summary>
        /// Calculates angle between movement direction (* -1) and normal and returns true if angle is valid
        /// </summary>
        /// <param name="direction">Movement direction</param>
        /// <param name="normal">Surface normal</param>
        /// <returns>Valid angle</returns>
        public bool IsValid(Vector3 direction, Vector3 normal)
        {
            var angle = Mathf.Acos(Vector3.Dot(-direction.normalized, normal.normalized)) * Mathf.Rad2Deg;
            return angle >= _minAngle;
        }
    }
}