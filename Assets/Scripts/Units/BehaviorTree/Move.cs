using BananaParty.BehaviorTree;
using CharacterMovement;
using Extensions;
using Units.BehaviorTree.Variables;
using UnityEngine;

namespace Units.BehaviorTree
{
    public class Move : BehaviorNode
    {
        private readonly IMovement _movement;
        private readonly ISharedVariable<Vector3> _direction;
        private readonly ISharedVariable<Vector3> _destination;

        public Move(IMovement movement, ISharedVariable<Vector3> direction, ISharedVariable<Vector3> destination)
        {
            _movement = movement;
            _direction = direction;
            _destination = destination;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_movement.Position.Close(_destination.Value, 0.1f)) return BehaviorNodeStatus.Success;
            if (_destination.Value == Vector3.zero) return BehaviorNodeStatus.Success;
            _direction.Value = _destination.Value - _movement.Position;
            
            _movement.Move(_direction.Value.normalized);
            return BehaviorNodeStatus.Failure;
        }
    }
}