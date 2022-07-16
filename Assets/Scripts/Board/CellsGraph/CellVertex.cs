using System.Collections.Generic;

namespace Game.Board
{
    public class CellVertex : IConstructableVertex<ICell>
    {
        private readonly List<IVertex<ICell>> _childs;
        public CellVertex(ICell origin, IVertex<ICell>[] childs) : this(origin)
        {
            _childs = new List<IVertex<ICell>>(childs);
        }
        public CellVertex(ICell origin)
        {
            Origin = origin;
            _childs = new List<IVertex<ICell>>();
        }
        
        public ICell Origin { get; }
        public IVertex<ICell>[] Childs => _childs.ToArray();
        public void AddChild(IVertex<ICell> child)
        {
            if (_childs.Contains(child)) return;
            _childs.Add(child);
        }
    }
}