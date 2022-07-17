namespace Units.BehaviorTree.Variables
{
    public interface ISharedVariable<T>
    {
        T Value { get; set; }
    }
}