using System.Collections;
using UnityEngine;

namespace Game.Board
{
    public interface IGraph<TVertex> : IEnumerable
    {
        void Write(TVertex vertex, Vector2Int position);
        TVertex this[int x, int y] { get; }
    }
}