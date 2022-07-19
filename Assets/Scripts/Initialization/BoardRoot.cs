using Game.Board;

namespace Game.Initialization
{
    public class BoardRoot : ICompositeRoot
    {
        private readonly BoardFactory _factory;
        
        public PlayBoard Board { get; private set; }

        public BoardRoot(BoardFactory factory)
        {
            _factory = factory;
        }

        public void Compose()
        {
            Board = _factory.Instantiate();
        }
    }
}