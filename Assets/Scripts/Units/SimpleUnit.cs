using BananaParty.BehaviorTree;
using CharacterMovement;
using CharacterMovement.Movement;
using Game.Board;
using Pathfinding;
using Units.BehaviorTree;
using Units.BehaviorTree.Variables;
using UnityEngine;

namespace Units
{
    public class SimpleUnit : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;

        private ITree _behavior;
        private readonly ISharedVariable<Vector3> _destination = new Destination();
        private readonly ISharedVariable<Vector3> _direction = new Direction();
        private readonly ISharedVariable<IPath> _path = new BehaviorTree.Variables.Path();

        private AlongSurface _movement;

        public void Init(IBoard board)
        {
            var rigidbody = GetComponent<Rigidbody>();
            _movement = new AlongSurface(
                rigidbody,
                new Speed(
                    _speed),
                new IRaycast.Default(
                    Mathf.Infinity,
                    1),
                new MovementAngle(
                    0f));

            _behavior = new TreeEntry(
                new SequenceNode(
                    new IBehaviorNode[]
                    {
                        new FindPath(
                            _path,
                            new BreadthFirst(
                                board),
                            board.Cell(new Vector2Int(0, 0)),
                            board.Cell(new Vector2Int(9, 9))),
                        new RepeatNode(
                            new SequenceNode(
                                new IBehaviorNode[]
                                {
                                    new RepeatNode(
                                        new SequenceNode(
                                            new IBehaviorNode[]
                                            {
                                                new NextDestination(
                                                    _path,
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
                            BehaviorNodeStatus.Failure)
                    }));


        }

        private void FixedUpdate()
        {
            _behavior.Execute(Time.time);
        }
    }
}