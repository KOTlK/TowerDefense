using UnityEngine;

namespace CharacterMovement
{
    public sealed class ValidNormal
    {
        private readonly NormalRestrictions _restrictions;

        public ValidNormal(NormalRestrictions restrictions)
        {
            _restrictions = restrictions;
        }

        public bool IsValid(Vector3 normal)
        {
            if (normal == Vector3.zero) return false;
            
            if (normal.x >= _restrictions.X ||
                normal.x <= -_restrictions.X ||
                normal.y <= _restrictions.Y ||
                normal.z >= _restrictions.Z ||
                normal.z <= -_restrictions.Z) 
                return false;

            return true;
        }
    }
}