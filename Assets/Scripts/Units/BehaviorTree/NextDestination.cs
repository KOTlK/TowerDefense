using BananaParty.BehaviorTree;
using Units.BehaviorTree.Variables;
using UnityEngine;

namespace Units.BehaviorTree
{
    public class NextDestination : BehaviorNode
    {
        private readonly Vector3[] _navigationPoints;
        private readonly IMutableVariable<Vector3> _destination;
        private readonly IMutableVariable<Vector3> _direction;

        private int _current = 0;

        public NextDestination(Vector3[] navigationPoints, IMutableVariable<Vector3> destination)
        {
            _navigationPoints = navigationPoints;
            _destination = destination;
        }


        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_navigationPoints.Length < _current)
            {
                _destination.Value = Vector3.zero;
                _direction.Value = Vector3.zero;
                return BehaviorNodeStatus.Failure;
            }
            
            _destination.Value = _navigationPoints[_current];
            _current++;
            return BehaviorNodeStatus.Success;
        }
    }
}