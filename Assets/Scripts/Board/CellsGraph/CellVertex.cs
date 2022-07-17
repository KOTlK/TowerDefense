using System.Collections.Generic;

namespace Game.Board
{
    public class CellVertex : IConstructableVertex<IContentCell>
    {
        private readonly List<IVertex<IContentCell>> _neighbours;
        public CellVertex(IContentCell origin, IVertex<IContentCell>[] neighbours) : this(origin)
        {
            _neighbours = new List<IVertex<IContentCell>>(neighbours);
        }
        public CellVertex(IContentCell origin)
        {
            Origin = origin;
            _neighbours = new List<IVertex<IContentCell>>();
        }
        
        public IContentCell Origin { get; }
        public IVertex<IContentCell>[] Neighbours => _neighbours.ToArray();
        public void AddNeighbour(IVertex<IContentCell> child)
        {
            if (_neighbours.Contains(child)) return;
            _neighbours.Add(child);
        }
    }
}