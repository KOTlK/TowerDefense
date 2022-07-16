using System.Collections;
using UnityEngine;

namespace Game.Board
{
    public class CellGraph : IGraph<CellVertex>
    {
        private readonly CellVertex[,] _vertices;
        
        public CellGraph(CellVertex[,] vertices)
        {
            _vertices = vertices;
        }

        public CellVertex this[int x, int y] => _vertices[x, y];

        public void Write(CellVertex vertex, Vector2Int position)
        {
            _vertices[position.x, position.y] = vertex;
        }

        public IEnumerator GetEnumerator()
        {
            return _vertices.GetEnumerator();
        }
    }
}