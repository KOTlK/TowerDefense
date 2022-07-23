using BananaParty.BehaviorTree;
using Game.Board.Content.Behavior;
using Game.Board.Content.Behavior.Variables;
using Game.Weapon;
using Game.Hp;
using Units;
using Units.BehaviorTree;
using Units.BehaviorTree.Variables;
using UnityEngine;
using Utils;
using Shoot = Game.Board.Content.Behavior.Shoot;

namespace Game.Board.Content
{
    public class Tower : MonoBehaviour, IDamageable, ICellContent
    {
        [SerializeField] private Transform _bulletsPivot;
        [SerializeField] private int _gunCooldownInMs = 2000;
        [SerializeField] private float _maxHp = 100f;
        [SerializeField] private Vector3 _rotationPerFrame = new(0, 0.1f, 0);
        [SerializeField] private float _fov = 60f;
        [SerializeField] private float _radius = 5f;
        
        private IHealth _hp;
        private IHealthView _healthView;
        private ITree _behavior;
        private IWeapon _weapon;
        private Bounds _bounds;

        private readonly ISharedVariable<SimpleUnit> _target = new Target();

        public void Init(IHealthView healthView, IObjectPool<IProjectile> pool)
        {
            _bounds = GetComponent<Collider>().bounds;
            _hp = new Health(_maxHp);
            _healthView = healthView;
            _hp.Changed += _ => _hp.Draw(_healthView);
            _weapon = new PlasmaGun(pool, _bulletsPivot, _gunCooldownInMs);

            _behavior = new TreeEntry(
                new RepeatNode(
                    new SequenceNode(
                        new IBehaviorNode[]
                        {
                            new RepeatNode(
                                new ParallelSequenceNode(
                                    new IBehaviorNode[]
                                    {
                                        new SequenceNode(
                                            new IBehaviorNode[]
                                            {
                                                new FindTarget(
                                                    transform,
                                                    _radius,
                                                    _fov,
                                                    _target),
                                                new WaitNode(
                                                    100)
                                            }),
                                        new ConstantRotation(
                                            transform,
                                            _rotationPerFrame)
                                    }),
                                BehaviorNodeStatus.Success),
                            new RepeatNode(
                                new ParallelSequenceNode(
                                    new IBehaviorNode[]
                                    {
                                        new LookAtTarget(
                                            transform,
                                            _target),
                                        
                                        new SequenceNode(
                                            new IBehaviorNode[]
                                            {
                                                new Shoot(
                                                    transform,
                                                    _target,
                                                    _weapon,
                                                    _radius),
                                                new WaitNode(
                                                    2000)
                                            })
                                        
                                    }),
                                BehaviorNodeStatus.Failure)
                        }),
                    BehaviorNodeStatus.Failure));
        }

        public void ApplyDamage(float amount)
        {
            _hp.Lose(amount);
        }

        public void Place(Vector3 position)
        {
            transform.position = position + new Vector3(0, _bounds.extents.y, 0);
        }
        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            _behavior.Execute(Time.time);
        }

        private void OnDestroy()
        {
            _hp.Changed -= _ => _hp.Draw(_healthView);
        }
    }
}