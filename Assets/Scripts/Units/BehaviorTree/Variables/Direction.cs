using UnityEngine;

namespace Units.BehaviorTree.Variables
{
    public class Direction : IMutableVariable<Vector3>
    {
        public Direction() : this(Vector3.zero){}
        public Direction(Vector3 value)
        {
            Value = value;
        }

        public Vector3 Value { get; set; }
    }
}