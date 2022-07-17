using BananaParty.BehaviorTree;
using Game.Board;
using Pathfinding;
using Units.BehaviorTree.Variables;

namespace Units.BehaviorTree
{
    public class FindPath : BehaviorNode
    {
        private readonly ISharedVariable<IPath> _path;
        private readonly IPathfinding _algorithm;
        private readonly IVertex<IContentCell> _start;
        private readonly IVertex<IContentCell> _end;

        public FindPath(ISharedVariable<IPath> path, IPathfinding algorithm, IVertex<IContentCell> start, IVertex<IContentCell> end)
        {
            _path = path;
            _algorithm = algorithm;
            _start = start;
            _end = end;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _path.Value = _algorithm.Find(_start, _end);
            return BehaviorNodeStatus.Success;
        }
    }
}