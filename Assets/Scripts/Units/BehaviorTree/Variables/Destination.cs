using UnityEngine;

namespace Units.BehaviorTree.Variables
{
    public class Destination : IMutableVariable<Vector3>
    {
        public Destination() : this(Vector3.zero){}
        public Destination(Vector3 value)
        {
            Value = value;
        }

        public Vector3 Value { get; set; }
    }
}