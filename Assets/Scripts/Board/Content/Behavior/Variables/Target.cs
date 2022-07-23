using Units;
using Units.BehaviorTree.Variables;

namespace Game.Board.Content.Behavior.Variables
{
    public class Target : ISharedVariable<SimpleUnit>
    {
        public SimpleUnit Value { get; set; }
    }
}