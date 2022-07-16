using System.Collections;
using UnityEngine;

namespace Game.Board
{
    public class PlayBoard : IBoard, IEnumerable
    {
        private readonly IGraph<CellVertex> _graph;

        public PlayBoard(IGraph<CellVertex> graph)
        {
            _graph = graph;
        }

        public CellVertex Cell(Vector2Int position)
        {
            return _graph[position.x, position.y];
        }

        public IEnumerator GetEnumerator()
        {
            return _graph.GetEnumerator();
        }
    }
}