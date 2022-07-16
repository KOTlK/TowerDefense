using Game.Board;

namespace Pathfinding
{
    public interface IPath
    {
        IVertex<ICell> Current { get; }
        bool Next();
    }
}