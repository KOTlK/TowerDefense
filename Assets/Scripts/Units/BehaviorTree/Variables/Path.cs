using Pathfinding;

namespace Units.BehaviorTree.Variables
{
    public class Path : ISharedVariable<IPath>
    {
        public IPath Value { get; set; }
    }
}