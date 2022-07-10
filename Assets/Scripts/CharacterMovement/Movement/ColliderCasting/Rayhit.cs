using System;
using UnityEngine;

namespace CharacterMovement.Movement
{
    public struct Rayhit
    {
        private readonly Vector3[] _points;
        private readonly Vector3[] _normals;

        public Rayhit(Vector3[] points, Vector3[] normals)
        {
            _points = points;
            _normals = normals;
        }

        public static Rayhit None = new Rayhit(Array.Empty<Vector3>(), Array.Empty<Vector3>());

        public Vector3[] Points => _points;
        public Vector3[] Normals => _normals;
        public Vector3 Point => _points == Array.Empty<Vector3>() ? Vector3.zero : _points[0];
        public Vector3 Normal => _normals == Array.Empty<Vector3>() ? Vector3.zero : _normals[0];
        

        public static bool operator ==(Rayhit first, Rayhit second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Rayhit first, Rayhit second)
        {
            return !first.Equals(second);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is Rayhit == false) return false;

            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return _points.GetHashCode() + _normals.GetHashCode();
        }
    }
}