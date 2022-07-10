using UnityEngine;

namespace Game.Board
{
    public interface IVertex<T>
    {
        IVertex<T>[] Childs { get; }
        ICell Origin { get; }
        void WriteToGraph(IGraph<IVertex<T>> graph, Vector2Int position);
    }
}