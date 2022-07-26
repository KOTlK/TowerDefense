using System;
using Game.Board;

namespace PlayerInput
{
    public interface IPointerInput
    {
        event Action<IContentCell> CellSelected;
        event Action<IContentCell> CellClicked;
    }
}