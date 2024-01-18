namespace _Project.AI.Core
{
    public interface IActorAction
    {
        bool IsComplete { get; }
        void Execute();
    }
}