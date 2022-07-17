using Game.Board;
using Units;
using UnityEngine;

namespace Initialization
{
    public class Main : MonoBehaviour
    {
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

            var unit = new UnitFactory(_board.Board).Instantiate();





        }
        
    }
}