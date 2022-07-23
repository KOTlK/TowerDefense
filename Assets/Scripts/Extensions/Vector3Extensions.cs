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

        public static bool InSight(this Vector3 point, Transform origin, float fov)
        {
            var direction = point - origin.position;
            return Mathf.Acos(Vector3.Dot(origin.forward.normalized, direction.normalized)) * Mathf.Rad2Deg >= fov;
        }
    }
}