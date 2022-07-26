using BananaParty.BehaviorTree;
using Extensions;
using Game.Board.Content.Behavior.Variables;
using Units;
using Units.BehaviorTree.Variables;
using UnityEngine;

namespace Game.Board.Content.Behavior
{
    public class FindTarget : BehaviorNode
    {
        private readonly Transform _origin;
        private readonly float _radius;
        private readonly float _fov;
        private readonly ISharedVariable<SimpleUnit> _target;

        public FindTarget(Transform origin, float radius, float fov, ISharedVariable<SimpleUnit> target)
        {
            _origin = origin;
            _radius = radius;
            _fov = fov;
            _target = target;
        }


        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_target.Value != null) return BehaviorNodeStatus.Failure;
            var results = new Collider[160];
            if (Physics.OverlapSphereNonAlloc(_origin.position, _radius, results) == 0)
                return BehaviorNodeStatus.Failure;

            foreach (var collider in results)
            {
                if (collider == null) break;
                if (collider.gameObject.TryGetComponent(out SimpleUnit unit))
                {
                    if (unit.Position.InSight(_origin, _fov))
                    {
                        _target.Value = unit;
                        _target.Value.Died += OnUnitDeath;
                        return BehaviorNodeStatus.Success;
                    }
                }
            }

            _target.Value = null;
            return BehaviorNodeStatus.Failure;
        }

        private void OnUnitDeath()
        {
            var target = _target.Value;
            _target.Value = null;
            target.Died -= OnUnitDeath;
        }
    }
}