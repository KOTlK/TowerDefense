using BananaParty.BehaviorTree;

namespace Units.BehaviorTree
{
    public class TreeEntry : ITree
    {
        private readonly BehaviorNode _entryNode;

        public TreeEntry(BehaviorNode entryNode)
        {
            _entryNode = entryNode;
        }

        public void Execute(float time)
        {
            _entryNode.Execute((long) time);
        }
    }
}