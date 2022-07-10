using UnityEngine;

namespace Game.Board
{
    public class CellGraph : IGraph<IVertex<ICell>>
    {
        private readonly IVertex<ICell>[,] _vertices;
        
        public CellGraph(IVertex<ICell>[,] vertices)
        {
            _vertices = vertices;
        }

        public IVertex<ICell> this[int x, int y] => _vertices[x, y];

        public void Write(IVertex<ICell> vertex, Vector2Int position)
        {
            _vertices[position.x, position.y] = vertex;
        }
        
    }
}