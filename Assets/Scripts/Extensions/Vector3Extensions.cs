using UnityEngine;

namespace Extensions
{
    public static class Vector3Extensions
    {
        public static bool Close(this Vector3 first, Vector3 second, float maxDistance)
        {
            var direction = second - first;
            return direction.sqrMagnitude <= maxDistance;
        }
    }
}