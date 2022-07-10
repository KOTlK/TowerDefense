using UnityEngine;

namespace Game.Board
{
    public interface ICell
    {
        Vector3 Pivot { get; }
        Vector3 Position { get; }
        IBuilding Building { get; }
        void Build(IBuilding building);
        void DestroyBuilding();
    }
}