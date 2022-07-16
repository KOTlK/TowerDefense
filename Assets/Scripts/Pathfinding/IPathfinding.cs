using UnityEngine;

namespace Pathfinding
{
    public interface IPathfinding<in TVertex>
    {
        IPath Find(TVertex startVertex, TVertex endVertex);
    }
}