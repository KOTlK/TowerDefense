using Game.Board;

namespace Pathfinding
{
    public interface IPath
    {
        IVertex<ICell> this[int index] { get; }
        int Length { get; }
        
    }
}