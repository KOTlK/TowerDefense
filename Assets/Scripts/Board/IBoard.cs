using UnityEngine;

namespace Game.Board
{
    public interface IBoard
    {
        ICell Cell(Vector2Int position);
    }
}