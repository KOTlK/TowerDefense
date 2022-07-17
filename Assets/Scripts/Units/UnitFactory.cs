using Game.Board;
using UnityEngine;
using Utils;

namespace Units
{
    public class UnitFactory : IFactory<SimpleUnit>
    {
        private readonly IBoard _board;

        private const string Path = "Prefabs/SimpleUnit";

        public UnitFactory(IBoard board)
        {
            _board = board;
        }

        public SimpleUnit Instantiate()
        {
            var prefab = Resources.Load<SimpleUnit>(Path);
            var unit = Object.Instantiate(prefab);
            unit.Init(_board);
            unit.transform.position = _board.Cell(new Vector2Int(0, 0)).Origin.Pivot + new Vector3(0, 1, 0);
            return unit;
        }
    }
}