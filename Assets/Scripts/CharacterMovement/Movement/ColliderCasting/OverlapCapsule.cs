using UnityEngine;
using CharacterMovement.Movement.Extensions;

namespace CharacterMovement.Movement
{
    public class OverlapCapsule : IOverlapCollider
    {
        private readonly Capsule _capsule;

        private Vector3 _point1 = Vector3.zero;
        private Vector3 _point2 = Vector3.zero;
        
        public OverlapCapsule(Capsule capsule)
        {
            _capsule = capsule;
        }

        public OverlapContacts Cast(Vector3 position)
        {
            _point1 = position - Vector3.up * _capsule.Height * 0.5f;
            _point2 = _point1 + Vector3.up * _capsule.Height;
            
            var results = new Collider[16];
            if (Physics.OverlapCapsuleNonAlloc(_point1, _point2, _capsule.Radius, results) == 0)
            {
                return OverlapContacts.Zero;
            }

            return results.ExtractContacts();
        }

        public void DrawGizmos()
        {
            Gizmos.DrawSphere(_point1, _capsule.Radius);
            Gizmos.DrawSphere(_point2, _capsule.Radius);

        }
    }
}