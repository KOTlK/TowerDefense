namespace Game.Board
{
    public interface IVertex<out T>
    {
        IVertex<T>[] Childs { get; }
        T Origin { get; }
    }
}