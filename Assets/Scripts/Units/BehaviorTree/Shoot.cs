using BananaParty.BehaviorTree;
using Game.Weapon;
using Units.BehaviorTree.Variables;
using UnityEngine;

namespace Units.BehaviorTree
{
    public class Shoot : BehaviorNode
    {
        private readonly ISharedVariable<Transform> _target;
        private readonly IWeapon _weapon;
        //for tests
        private readonly ISharedVariable<Vector3> _direction;

        //for tests
        public Shoot(IWeapon weapon, ISharedVariable<Vector3> direction)
        {
            _weapon = weapon;
            _direction = direction;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _weapon.Shoot(_direction.Value);
            return BehaviorNodeStatus.Success;
        }
    }
}