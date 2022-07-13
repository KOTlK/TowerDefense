using BananaParty.BehaviorTree;
using CharacterMovement;
using CharacterMovement.Movement;
using Units.BehaviorTree;
using Units.BehaviorTree.Variables;
using UnityEngine;

namespace Units
{
    public class SimpleUnit : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Vector3[] _navPoints;

        private ITree _behavior;
        private IMutableVariable<Vector3> _destination = new Destination();
        private IMutableVariable<Vector3> _direction = new Direction();
        
        private Rigidbody _rigidbody;
        private AlongSurface _movement;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _movement = new AlongSurface(
                _rigidbody,
                new Speed(
                    _speed),
                new IRaycast.Default(
                    Mathf.Infinity,
                    1),
                new MovementAngle(
                    0f));

            _behavior = new TreeEntry(
                new RepeatNode(
                    new SequenceNode(
                        new IBehaviorNode[]
                        {
                            new RepeatNode(
                                new SequenceNode(
                                    new IBehaviorNode[]
                                    {
                                        new NextDestination(
                                            _navPoints,
                                            _destination),
                                        new ParallelSequenceNode(
                                            new IBehaviorNode[]
                                            {
                                                new RepeatNode(
                                                    new InverterNode(
                                                        new Move(
                                                            _movement,
                                                            _direction,
                                                            _destination)),
                                                    BehaviorNodeStatus.Failure)
                                            })
                                    }),
                                BehaviorNodeStatus.Failure)
                        }),
                    BehaviorNodeStatus.Failure));

        }

        private void FixedUpdate()
        {
            _behavior.Execute(Time.time);
        }
    }
}