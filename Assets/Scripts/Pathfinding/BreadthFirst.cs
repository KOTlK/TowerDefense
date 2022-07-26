using System;
using System.Collections.Generic;
using Game.Board;

namespace Pathfinding
{
    public class BreadthFirst : IPathfinding
    {
        private readonly IBoard _board;

        public BreadthFirst(IBoard board)
        {
            _board = board;
        }

        
        public IPath Find(IVertex<IContentCell> startVertex, IVertex<IContentCell> endVertex)
        {
            if (startVertex.Origin.Content is IContent.Empty == false)
                throw new ArgumentException($"{nameof(startVertex)} should be {nameof(IContent.Empty)}");

            if (endVertex.Origin.Content is IContent.Empty == false)
                throw new ArgumentException($"{nameof(endVertex)} should be {nameof(IContent.Empty)}");
            
            var frontier = new Queue<IVertex<IContentCell>>();
            frontier.Enqueue(startVertex);
            var cameFrom = new Dictionary<IVertex<IContentCell>, IVertex<IContentCell>> {{startVertex, null}};

            while (frontier.Count != 0)
            {
                var current = frontier.Dequeue();
                foreach (var child in current.Neighbours)
                {
                    if (child.Origin.Content is IContent.Empty == false) continue;
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