namespace Game.Board
{
    public interface IContentCell : ICell
    {
        ICellContent Content { get; }
        void Build(ICellContent cellContent);
        void DestroyBuilding();
    }
}