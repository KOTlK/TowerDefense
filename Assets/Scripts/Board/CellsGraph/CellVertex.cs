using System;
using UnityEngine;

namespace Game.Board
{
    public class CellVertex : IVertex<ICell>, ICell
    {
        public CellVertex(ICell origin, IVertex<ICell>[] childs) : this(origin)
        {
            Childs = childs;
        }
        public CellVertex(ICell origin)
        {
            Origin = origin;
            Childs = Array.Empty<IVertex<ICell>>();
        }
        
        public ICell Origin { get; }
        public IVertex<ICell>[] Childs { get; private set; }
        public Vector3 Pivot => Origin.Pivot;
        public Vector3 Position => Origin.Position;
        public IBuilding Building => Origin.Building;

        public void Build(IBuilding building) => Origin.Build(building);
        public void DestroyBuilding() => Origin.DestroyBuilding();
        
        public void WriteToGraph(IGraph<IVertex<ICell>> graph, Vector2Int position)
        {
            graph.Write(this, position);
        }
    }
}