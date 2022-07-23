using UnityEngine;

namespace Units
{
    public interface IMovingUnit
    {
        Vector3 Position { get; }
        Vector3 PredictPosition(float time);
    }
}