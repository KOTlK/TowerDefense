namespace Game.Board
{
    public interface IContentCell : ICell
    {
        ICellContent CellContent { get; }
        void Build(ICellContent cellContent);
        void DestroyBuilding();
    }
}