namespace _Project.AI.Core
{
    public interface IPassiveAction<in TContext> where TContext : IActorContext
    {
        bool CanApply(TContext context);
        void Apply(TContext context, float delta);
    }
}