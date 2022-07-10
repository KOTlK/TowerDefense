using UnityEngine;

namespace CharacterMovement.Movement
{
    public interface IColliderCast
    {
        Contacts Cast(Vector3 direction);
    }
}