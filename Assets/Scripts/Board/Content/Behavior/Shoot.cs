using BananaParty.BehaviorTree;
using Game.Weapon;
using Units;
using Units.BehaviorTree.Variables;
using UnityEngine;

namespace Game.Board.Content.Behavior
{
    public class Shoot : BehaviorNode
    {
        private readonly Transform _origin;
        private readonly ISharedVariable<SimpleUnit> _target;
        private readonly IWeapon _weapon;
        private readonly float _maxDistance;

        public Shoot(Transform origin, ISharedVariable<SimpleUnit> target, IWeapon weapon, float maxDistance)
        {
            _origin = origin;
            _target = target;
            _weapon = weapon;
            _maxDistance = maxDistance;
        }


        public override BehaviorNodeStatus OnExecute(long time)
        {
            var direction = _target.Value.Position - _origin.position;
            if (direction.magnitude >= _maxDistance)
            {
                _target.Value = null;
                return BehaviorNodeStatus.Failure;
            }
            
            _weapon.Shoot((_target.Value.PredictPosition(0.3f) - _origin.position).normalized);
            return BehaviorNodeStatus.Success;
        }
    }
}