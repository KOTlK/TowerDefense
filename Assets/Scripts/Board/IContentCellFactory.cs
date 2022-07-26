using System;
using Utils;
using Object = UnityEngine.Object;

namespace Game.Board
{
    public interface IContentCellFactory<out TCell> : IPrefabFactory<TCell>
        where TCell : Object, IContentCell
    {
        event Action<IContentCell> CellClicked;
        event Action<IContentCell> CellSelected;
        TCell[] SpawnedContent { get; }
    }
}