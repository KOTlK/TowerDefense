using System;
using Game.Board;
using UnityEngine;

namespace Pathfinding
{
    public class Path : IPath
    {
        private readonly IVertex<ICell>[] _points;
        private int _index;

        public Path(IVertex<ICell>[] points)
        {
            if (points == Array.Empty<IVertex<ICell>>()) throw new ArgumentException("Path can't be empty", nameof(points));
            _points = points;
            _index = 0;
        }

        public IVertex<ICell> Current => _points[_index];
        
        public bool Next()
        {
            if (_index + 1 == _points.Length) return false;

            _index++;
            return true;
        }
    }
}