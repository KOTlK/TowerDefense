using Game.Board;
using Game.Weapon;
using Units;
using UnityEngine;
using Utils;

namespace Initialization
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Transform _projectilesParent;
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private Vector2Int _boardSize;

        private BoardRoot _board;
        private void Awake()
        {
            _board = new BoardRoot(
                new BoardFactory(
                    new CellFactory(
                        _cellPrefab,
                        new ICellContent.Empty()),
                    _boardSize,
                    new Vector2(
                        0.5f,
                        0.5f)));
            
            _board.Compose();

            var plasmaPool = new PlasmaPool(
                new PlasmaFactory(
                    _projectilesParent));

            var unit = new UnitFactory(_board.Board, plasmaPool).Instantiate();





        }
        
    }
}