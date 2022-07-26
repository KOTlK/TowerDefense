using Utils;

namespace Game.Board.ContentBuilding
{
    public interface ISelectedContent : IContent
    {
        void Build(IContentCell cell);
        void Select(IFactory<IContent> factory);
    }
}