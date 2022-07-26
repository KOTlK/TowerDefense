using System;
using Game.Board;
using UnityEngine;

namespace PlayerInput
{
    public class Keyboard : IPlayerInput
    {
        public event Action<IContentCell> CellSelected;
        public event Action<IContentCell> CellClicked;
        public event Action CancelPressed;

        private readonly IContentCellFactory<Cell> _factory;

        public Keyboard(IContentCellFactory<Cell> factory)
        {
            _factory = factory;
        }

        public void Bind()
        {
            _factory.CellSelected += SelectCell;
            _factory.CellClicked += ClickCell;
        }
        
        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CancelPressed?.Invoke();
            }
        }

        public void Unbind()
        {
            _factory.CellSelected -= SelectCell;
            _factory.CellClicked -= ClickCell;
        }

        private void SelectCell(IContentCell cell)
        {
            CellSelected?.Invoke(cell);
        }

        private void ClickCell(IContentCell cell)
        {
            CellClicked?.Invoke(cell);
        }
    }
}