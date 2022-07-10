using System.Collections;
using CharacterMovement;
using CharacterMovement.Movement;
using UnityEngine;

namespace Units
{
    public class SimpleUnit : MonoBehaviour, IMovable
    {
        [SerializeField] private float _speed = 10f;
        
        private Rigidbody _rigidbody;
        private AlongSurface _movement;
        private Coroutine _moving = null;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _movement = new AlongSurface(
                _rigidbody,
                new Speed(
                    _speed),
                new IRaycast.Default(
                    Mathf.Infinity,
                    1),
                new MovementAngle(
                    0f));
        }

        public void Move(Vector3 point)
        {
            if (_moving != null) return;
            _moving = StartCoroutine(Moving(point));
        }

        private IEnumerator Moving(Vector3 point)
        {
            Debug.Log("Movement Started");
            
            while (Close(_movement.Position, point, 0.1f) == false)
            {
                var direction = point - _rigidbody.position;
                _movement.Move(direction.normalized);
                yield return new WaitForFixedUpdate();
            }

            _moving = null;
            Debug.Log("Movement Ended");
        }

        private bool Close(Vector3 first, Vector3 second, float distance)
        {
            var direction = second - first;
            return direction.sqrMagnitude <= distance;
        }
    }
}