namespace Game.Board
{
    public interface IConstructableVertex<T> : IVertex<T>
    {
        void AddChild(IVertex<T> child);
    }
}