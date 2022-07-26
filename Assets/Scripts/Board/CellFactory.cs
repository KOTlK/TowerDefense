using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Game.Board
{
    public class CellFactory : IContentCellFactory<Cell>
    {
        public event Action<IContentCell> CellClicked;
        public event Action<IContentCell> CellSelected;
        
        private readonly Cell _prefab;
        private readonly IContent _content;
        private readonly List<Cell> _spawned;

        public CellFactory(Cell prefab, IContent content)
        {
            _prefab = prefab;
            _content = content;
            _spawned = new List<Cell>();
        }

        public Cell[] SpawnedContent => _spawned.ToArray();
        
        public Cell Instantiate()
        {
            var cell = Object.Instantiate(_prefab);
            cell.Initialize(_content);
            cell.Clicked += () => ClickCell(cell);
            cell.Selected += () => SelectCell(cell);
            _spawned.Add(cell);
            return cell;
        }

        private void ClickCell(IContentCell cell)
        {
            CellClicked?.Invoke(cell);
        }

        private void SelectCell(IContentCell cell)
        {
            CellSelected?.Invoke(cell);
        }
        
    }
}