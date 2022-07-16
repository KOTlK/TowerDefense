using System.Diagnostics;
using Game.Board;
using Pathfinding;
using UnityEngine;
using Debug = UnityEngine.Debug;

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

            var pathfinding = new BreadthFirst(_board.Board);

            var path = pathfinding.Find(_board.Board.Cell(new Vector2Int(0, 5)), _board.Board.Cell(new Vector2Int(9, 1)));


            while (path.Next())
            {
                Debug.DrawRay(path.Current.Origin.Position, Vector3.up * 2f, Color.blue, Mathf.Infinity);
            }
            

        }
        
    }
}