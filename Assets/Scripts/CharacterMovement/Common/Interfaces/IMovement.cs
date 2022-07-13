using UnityEngine;

namespace CharacterMovement
{
    public interface IMovement
    {
        Vector3 Position { get; }
        void Move(Vector3 direction);
    }
}