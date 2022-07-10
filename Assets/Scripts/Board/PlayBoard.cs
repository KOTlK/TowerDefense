using UnityEngine;

namespace Game.Board
{
    public class PlayBoard : IBoard
    {

        private readonly IGraph<IVertex<ICell>> _graph;

        public PlayBoard(IGraph<IVertex<ICell>> graph)
        {
            _graph = graph;
        }

        public ICell Cell(Vector2Int position)
        {
            return _graph[position.x, position.y].Origin;
        }
    }
}