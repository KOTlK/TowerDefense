using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game.Board
{
    public class BoardFactory : IFactory<PlayBoard>
    {
        private readonly IFactory<Cell> _cellFactory;
        private readonly Vector2Int _size;
        private readonly Vector2 _padding;

        public BoardFactory(IFactory<Cell> cellFactory, Vector2Int size, Vector2 padding) : this(cellFactory, size)
        {
            _padding = padding;
        }
        public BoardFactory(IFactory<Cell> cellFactory, Vector2Int size)
        {
            _cellFactory = cellFactory;
            _size = size;
            _padding = Vector2.zero;
        }

        public PlayBoard Instantiate()
        {
            var vertices = InstantiateCells();
            

            for (var y = 0; y < _size.y; y++)
            {
                for (var x = 0; x < _size.x; x++)
                {
                    if (x == 0 && y == 0)
                    {
                        var vertex = vertices[x, y];
                        vertex.AddChild(vertices[x + 1, y]);
                        vertices[x + 1, y].AddChild(vertex);
                        vertex.AddChild(vertices[x, y + 1]);
                        vertices[x, y + 1].AddChild(vertex);
                    }
                    else
                    {
                        var vertex = vertices[x, y];
                        
                        if (y < _size.y - 1)
                        {
                            vertex.AddChild(vertices[x, y + 1]);
                            vertices[x, y + 1].AddChild(vertex);
                        }

                        if (y > 0)
                        {
                            vertex.AddChild(vertices[x, y - 1]);
                            vertices[x, y - 1].AddChild(vertex);
                        }

                        if (x < _size.x - 1)
                        {
                            vertex.AddChild(vertices[x + 1, y]);
                            vertices[x + 1, y].AddChild(vertex);
                        }

                        if (x > 0)
                        {
                            vertex.AddChild(vertices[x - 1, y]);
                            vertices[x - 1, y].AddChild(vertex);
                        }
                    }

                }
            }


            return new PlayBoard(new CellGraph(vertices));
        }

        private CellVertex[,] InstantiateCells()
        {
            var cells = new ICell[_size.x, _size.y];
            var vertices = new CellVertex[_size.x, _size.y];

            for (var y = 0; y < _size.y; y++)
            {
                for (var x = 0; x < _size.x; x++)
                {
                    var cell = _cellFactory.Instantiate();
                    var offsetX = cell.GetComponent<Renderer>().bounds.size.x;
                    var offsetZ = cell.GetComponent<Renderer>().bounds.size.z;
                    
                    if (x == 0 && y == 0)
                    {
                        cell.transform.position = Vector3.zero;
                    }

                    if (x == 0 && y != 0)
                    {
                        cell.transform.position = cells[x, y - 1].Position + new Vector3(0, 0, offsetZ + _padding.y);
                    }

                    if (x > 0)
                    {
                        cell.transform.position = cells[x - 1, y].Position + new Vector3(offsetX + _padding.x, 0, 0);
                    }
                    
                    cells[x, y] = cell;
                    vertices[x, y] = new CellVertex(cell);
                }
            }

            return vertices;
        }
    }
}