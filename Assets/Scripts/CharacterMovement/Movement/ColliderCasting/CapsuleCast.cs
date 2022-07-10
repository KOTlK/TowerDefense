using UnityEngine;
using CharacterMovement.Movement.Extensions;

namespace CharacterMovement.Movement
{
    public class CapsuleCast : IColliderCast
    {
        private readonly Transform _origin;
        private readonly Capsule _capsule;
        private readonly LayerMask _ignoreMask;

        private Vector3 _direction = Vector3.zero;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin">Transform body</param>
        /// <param name="capsule">Capsule description</param>
        /// <param name="ignoreMask">Ignoring layers</param>
        public CapsuleCast(Transform origin, Capsule capsule, LayerMask ignoreMask)
        {
            _origin = origin;
            _capsule = capsule;
            _ignoreMask = ignoreMask;
        }

        /// <summary>
        /// Cast capsule in specified NORMALIZED direction
        /// </summary>
        /// <param name="direction">NORMALIZED cast direction</param>
        /// <returns>Contacted normals</returns>
        public Contacts Cast(Vector3 direction)
        {
            _direction = direction;
            var results = new RaycastHit[8];
            Vector3 point1;

            if (_capsule.Height <= 1f)
            {
                point1 = _origin.position;

                if (Physics.SphereCastNonAlloc(point1, _capsule.Radius, direction, results, 1f, ~_ignoreMask) == 0)
                {
                    return Contacts.None;
                }
            }
            else
            {
                point1 = _origin.position - Vector3.up * _capsule.Height * 0.5f;
                var point2 = point1 + Vector3.up * _capsule.Height;
            
                if (Physics.CapsuleCastNonAlloc(point1, point2, _capsule.Radius, direction, results, 1f, ~_ignoreMask) == 0)
                {
                    return Contacts.None;
                }
            }

            for (var i = 0; i < results.Length; i++)
            {
                if (results[i].point != Vector3.zero) continue;
                
                var hits = new RaycastHit[1];
                
                if(Physics.RaycastNonAlloc(_origin.position + _direction, -Vector3.up, hits, _capsule.Height) == 0 ) continue;
                
                results[i] = hits[0];
            }


            return results.ExtractContacts();
        }

        public void DrawGizmos()
        {
            Vector3 point1;
            
            if (_capsule.Height <= 1f)
            {
                point1 = _origin.position + _direction;
                Gizmos.DrawSphere(point1, _capsule.Radius);

            }
            else
            {
                point1 = _origin.position + _direction - Vector3.up * _capsule.Height * 0.5f;
                var point2 = point1 + Vector3.up * _capsule.Height;
            
                Gizmos.DrawSphere(point1, _capsule.Radius);
                Gizmos.DrawSphere(point2, _capsule.Radius);
            }
            
            
            
        }
        
    }
}