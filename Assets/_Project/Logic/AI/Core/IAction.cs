namespace _Project.AI.Core
{
    public interface IAction<in T> where T : IActorContext
    {
        bool CanApply(T context);
        void ApplyResult(T context);
    }
}