using System;
using System.Collections;
using UnityEngine;

namespace Game.Weapon
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Plasma : MonoBehaviour, IProjectile
    {
        public event Action Hit;

        [SerializeField] private float _damage = 30f;
        [SerializeField] private float _flightTime = 6f;
        [SerializeField] private float _maxDistance = 100f;

        private Rigidbody _rigidbody;
        private Coroutine _coroutine;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_damage);
                Deactivate();
            }
        }


        public void Shoot(Vector3 startPosition, Vector3 direction)
        {
            if (_coroutine != null) return;
            gameObject.SetActive(true);
            _coroutine = StartCoroutine(Shooting(startPosition, direction));
        }

        private IEnumerator Shooting(Vector3 startPosition, Vector3 direction)
        {
            var endPosition = startPosition + direction * _maxDistance;
            var elapsedTime = 0f;

            while (elapsedTime < _flightTime)
            {
                elapsedTime += Time.deltaTime;
                var progress = elapsedTime / _flightTime;
                _rigidbody.MovePosition(Vector3.Lerp(startPosition, endPosition, progress));

                yield return null;
            }

            Deactivate();
        }

        private void Deactivate()
        {
            StopAllCoroutines();
            _coroutine = null;
            gameObject.SetActive(false);
            Hit?.Invoke();
        }
    }
}