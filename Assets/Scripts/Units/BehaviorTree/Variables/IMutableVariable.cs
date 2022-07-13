namespace Units.BehaviorTree.Variables
{
    public interface IMutableVariable<T>
    {
        T Value { get; set; }
    }
}