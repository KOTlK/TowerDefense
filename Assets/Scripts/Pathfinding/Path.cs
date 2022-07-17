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
        }

        public IVertex<ICell> this[int index] => _points[index];
        public int Length => _points.Length;
    }
}