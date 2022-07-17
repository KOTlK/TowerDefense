using Game.Board;
using UnityEngine;

namespace Pathfinding
{
    public interface IPathfinding
    {
        IPath Find(IVertex<IContentCell> startVertex, IVertex<IContentCell> endVertex);
    }
}