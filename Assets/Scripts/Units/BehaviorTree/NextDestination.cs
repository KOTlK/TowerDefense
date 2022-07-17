using BananaParty.BehaviorTree;
using Pathfinding;
using Units.BehaviorTree.Variables;
using UnityEngine;

namespace Units.BehaviorTree
{
    public class NextDestination : BehaviorNode
    {
        private readonly ISharedVariable<IPath> _path;
        private readonly ISharedVariable<Vector3> _destination;

        private int _index = 0;

        public NextDestination(ISharedVariable<IPath> path, ISharedVariable<Vector3> destination)
        {
            _path = path;
            _destination = destination;
        }
        
        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_index + 1 == _path.Value.Length) return BehaviorNodeStatus.Failure;
            _index++;
            _destination.Value = _path.Value[_index].Origin.Pivot;
            Debug.Log("Called next destination");
            Debug.DrawRay(_destination.Value, Vector3.up * 5f, Color.blue, Mathf.Infinity);
            return BehaviorNodeStatus.Success;
        }
    }
}