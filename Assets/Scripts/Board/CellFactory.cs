using UnityEngine;
using Utils;

namespace Game.Board
{
    public class CellFactory : IPrefabFactory<Cell>
    {
        private readonly Cell _prefab;
        private readonly IBuilding _building;

        public CellFactory(Cell prefab, IBuilding building)
        {
            _prefab = prefab;
            _building = building;
        }


        public Cell Instantiate()
        {
            var cell = Object.Instantiate(_prefab);
            cell.Initialize(_building);
            return cell;
        }

    }
}