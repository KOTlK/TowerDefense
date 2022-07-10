using UnityEngine;

namespace CharacterMovement.Movement
{
    public interface IOverlapCollider
    {
        OverlapContacts Cast(Vector3 position);
    }
}