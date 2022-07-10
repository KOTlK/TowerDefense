using UnityEngine;

namespace CharacterMovement
{
    public readonly struct NormalRestrictions
    {
        public NormalRestrictions(Vector3 restrictions) : this(restrictions.x, restrictions.y, restrictions.z)
        {
        }
        
        public NormalRestrictions(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        
    }
}