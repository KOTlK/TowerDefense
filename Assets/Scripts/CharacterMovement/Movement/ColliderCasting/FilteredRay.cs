using UnityEngine;
using CharacterMovement.Movement.Extensions;

namespace CharacterMovement.Movement
{
    public class FilteredRay : IRaycast
    {
        private readonly float _maxDistance;
        private readonly int _maxHits;
        private readonly LayerMask _ignoreMask;
        private readonly QueryTriggerInteraction _triggerInteraction;

        public FilteredRay(LayerMask ignoreMask, QueryTriggerInteraction triggerInteraction, float maxDistance = Mathf.Infinity, int maxHits = 1)
        {
            _maxDistance = maxDistance;
            _maxHits = maxHits;
            _ignoreMask = ignoreMask;
            _triggerInteraction = triggerInteraction;
        }

        public Rayhit Cast(Vector3 position, Vector3 direction)
        {
            var results = new RaycastHit[_maxHits];
            if (Physics.RaycastNonAlloc(position, 
                direction, 
                results, 
                _maxDistance, 
                ~_ignoreMask,
                _triggerInteraction) == 0) return Rayhit.None;

            return results.ExtractHits();
        }
    }
}