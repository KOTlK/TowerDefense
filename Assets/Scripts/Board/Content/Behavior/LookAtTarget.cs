using BananaParty.BehaviorTree;
using Units;
using Units.BehaviorTree.Variables;
using UnityEngine;

namespace Game.Board.Content.Behavior
{
    public class LookAtTarget : BehaviorNode
    {
        private readonly Transform _origin;
        private readonly ISharedVariable<SimpleUnit> _target;

        public LookAtTarget(Transform origin, ISharedVariable<SimpleUnit> target)
        {
            _origin = origin;
            _target = target;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_target.Value == null) return BehaviorNodeStatus.Failure;
            
            _origin.LookAt(_target.Value.Position);
            return BehaviorNodeStatus.Success;
        }
    }
}