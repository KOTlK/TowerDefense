using System.Collections.Generic;
using System.Linq;
using Game.Board;
using UnityEngine;

namespace Pathfinding
{
    public class BreadthFirst : IPathfinding<IVertex<ICell>>
    {
        private readonly IBoard _board;

        public BreadthFirst(IBoard board)
        {
            _board = board;
        }

        public IPath Find(IVertex<ICell> startVertex, IVertex<ICell> endVertex)
        {
            var frontier = new Queue<IVertex<ICell>>();
            frontier.Enqueue(startVertex);
            var cameFrom = new Dictionary<IVertex<ICell>, IVertex<ICell>> {{startVertex, null}};

            while (frontier.Count != 0)
            {
                var current = frontier.Dequeue();
                //Debug.DrawRay(current.Origin.Position, Vector3.up * 5f, Color.red, Mathf.Infinity);
                foreach (var child in current.Childs)
                {
                    //Debug.DrawRay(child.Origin.Position, Vector3.up * 2f, Color.blue, Mathf.Infinity);
                    if (cameFrom.ContainsKey(child) == false)
                    {
                        frontier.Enqueue(child);
                        cameFrom.Add(child, current);
                    }

                }
            }


            var currentVertex = endVertex;
            var path = new List<IVertex<ICell>>();
            path.Add(currentVertex);

            while (currentVertex != startVertex)
            {
                currentVertex = cameFrom[currentVertex];
                path.Add(currentVertex);
            }

            path.Add(startVertex);
            path.Reverse();

            return new Path(path.ToArray());
        }

    }
}