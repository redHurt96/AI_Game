namespace _Project.AI.Core
{
    public interface IBreakableAction<in TContext> where TContext : IActorContext
    {
        bool NeedToBreak(TContext context);
    }
}