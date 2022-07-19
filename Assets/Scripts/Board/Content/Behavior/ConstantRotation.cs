using BananaParty.BehaviorTree;
using UnityEngine;

namespace Game.Board.Content.Behavior
{
    public class ConstantRotation : BehaviorNode
    {
        private readonly Transform _origin;
        private readonly Vector3 _rotationPerFrame;

        public ConstantRotation(Transform origin, Vector3 rotationPerFrame)
        {
            _origin = origin;
            _rotationPerFrame = rotationPerFrame;
        }
        

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _origin.Rotate(_rotationPerFrame);
            return BehaviorNodeStatus.Success;
        }
    }
}