namespace Game.Board
{
    public interface IConstructableVertex<T> : IVertex<T>
    {
        void AddNeighbour(IVertex<T> child);
    }
}