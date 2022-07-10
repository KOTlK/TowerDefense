using UnityEngine;

namespace CharacterMovement
{
    public interface IMovement
    {
        void Move(Vector3 direction);
    }
}