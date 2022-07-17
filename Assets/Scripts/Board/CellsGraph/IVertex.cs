namespace Game.Board
{
    public interface IVertex<out T>
    {
        IVertex<T>[] Neighbours { get; }
        T Origin { get; }
    }
}