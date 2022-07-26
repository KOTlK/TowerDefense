namespace Game.Board
{
    public interface IContentCell : ICell, IClickableCell, ISelectableCell
    {
        IContent Content { get; }
        void Build(IContent content);
        void DestroyContent();
    }
}