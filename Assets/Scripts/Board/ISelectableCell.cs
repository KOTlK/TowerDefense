using System;

namespace Game.Board
{
    public interface ISelectableCell
    {
        event Action Selected;
    }
}