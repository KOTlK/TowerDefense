using System;
using Game.Board;
using Game.Board.Content;
using Game.Board.ContentBuilding;
using Game.Hp.View;
using Game.Weapon;
using PlayerInput;
using Units;
using UnityEngine;

namespace Game.Initialization
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Transform _projectilesParent;
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private Vector2Int _boardSize;

        private BoardRoot _board;
        private IPlayerInput _input;
        
        private void Awake()
        {
            var cellFactory = new CellFactory(_cellPrefab, new IContent.Empty());
            
            var plasmaPool = new PlasmaPool(
                new PlasmaFactory(
                    _projectilesParent));

            var towerFactory = new TowerFactory(
                new HpView().Instantiate(),
                plasmaPool);

            var tower = towerFactory.Instantiate();

            var selectedContent = new SelectedContent();
            selectedContent.Select(towerFactory);

            _input = new Keyboard(cellFactory);
            _input.CellClicked += _ => selectedContent.Build(_);
            _input.CellSelected += _ =>
            {
                if (_.Content is IContent.Empty == false) return;
                selectedContent.Place(_.Pivot);
            };
            _input.CancelPressed += () => Log("Canceled");
            _input.Bind();

            _board = new BoardRoot(
                new BoardFactory(
                    cellFactory,
                    _boardSize,
                    new Vector2(
                        0.5f,
                        0.5f)));
            
            _board.Compose();

            var unit = new UnitFactory(_board.Board, plasmaPool).Instantiate();
            
            _board.Board.Cell(new Vector2Int(4, 4)).Origin.Build(tower);
        }

        private void Update()
        {
            _input.Execute();
        }

        private void Log(string message)
        {
            Debug.Log(message);
        }
        
    }
}