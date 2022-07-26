using System;

namespace Game.Board
{
    public interface IClickableCell
    {
        event Action Clicked;
    }
}