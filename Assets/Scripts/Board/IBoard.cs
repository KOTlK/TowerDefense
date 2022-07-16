using UnityEngine;

namespace Game.Board
{
    public interface IBoard
    {
        CellVertex Cell(Vector2Int position);
    }
}