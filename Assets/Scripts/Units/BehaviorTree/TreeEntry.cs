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

        /// <summary>
        /// Executes tree
        /// </summary>
        /// <param name="time">Unity Time.time</param>
        public void Execute(float time)
        {
            _entryNode.Execute((long) (time * 1000));
        }
    }
}