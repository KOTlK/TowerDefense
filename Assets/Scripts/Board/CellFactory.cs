using UnityEngine;
using Utils;

namespace Game.Board
{
    public class CellFactory : IPrefabFactory<Cell>
    {
        private readonly Cell _prefab;
        private readonly ICellContent _cellContent;

        public CellFactory(Cell prefab, ICellContent cellContent)
        {
            _prefab = prefab;
            _cellContent = cellContent;
        }


        public Cell Instantiate()
        {
            var cell = Object.Instantiate(_prefab);
            cell.Initialize(_cellContent);
            return cell;
        }

    }
}