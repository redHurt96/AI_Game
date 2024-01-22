namespace _Project.AI.Core
{
    public interface IBehaviour
    {
        bool Completed { get; }
        void Execute();
    }
}