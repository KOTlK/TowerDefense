using BananaParty.BehaviorTree;
using Game.Board.Content.Behavior;
using Game.Weapon;
using Game.Hp;
using Units.BehaviorTree;
using UnityEngine;

namespace Game.Board.Content
{
    public class Tower : MonoBehaviour, IDamageable, ICellContent
    {
        [SerializeField] private float _maxHp = 100f;
        [SerializeField] private Vector3 _rotationPerFrame = new(0, 0.1f, 0);
        
        private IHealth _hp;
        private IHealthView _healthView;
        private ITree _behavior;
        private Bounds _bounds;

        public void Init(IHealthView healthView)
        {
            _bounds = GetComponent<Collider>().bounds;
            _hp = new Health(_maxHp);
            _healthView = healthView;
            _hp.Changed += _ => _hp.Draw(_healthView);

            _behavior = new TreeEntry(
                new RepeatNode(
                    new ConstantRotation(
                        transform,
                        _rotationPerFrame),
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

        private void Update()
        {
            _behavior.Execute(Time.time);
        }

        private void OnDestroy()
        {
            _hp.Changed -= _ => _hp.Draw(_healthView);
        }
    }
}