using UnityEngine;
using CharacterMovement.Movement.Extensions;


namespace CharacterMovement.Movement
{
    public class OverlapCapsuleFiltered : IOverlapCollider
    {
        private readonly Capsule _capsule;
        private readonly LayerMask _ignore;
        private readonly QueryTriggerInteraction _triggerInteraction;

        private Vector3 _point1 = Vector3.zero;
        private Vector3 _point2 = Vector3.zero;

        /// <summary>
        /// Project capsule in specified position
        /// </summary>
        /// <param name="capsule">Capsule description</param>
        /// <param name="ignore">Ignore mask. Everything that it include will be ignored by cast</param>
        /// <param name="triggerInteraction">Should cast include triggers?</param>
        public OverlapCapsuleFiltered(Capsule capsule, LayerMask ignore, QueryTriggerInteraction triggerInteraction)
        {
            _capsule = capsule;
            _ignore = ignore;
            _triggerInteraction = triggerInteraction;
        }

        public OverlapContacts Cast(Vector3 position)
        {
            _point1 = position - Vector3.up * _capsule.Height * 0.5f;
            _point2 = _point1 + Vector3.up * _capsule.Height;
            
            var results = new Collider[16];
            if (Physics.OverlapCapsuleNonAlloc(_point1, _point2, _capsule.Radius, results, ~_ignore, _triggerInteraction) == 0)
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