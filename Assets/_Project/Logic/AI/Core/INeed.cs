namespace _Project.AI.Core
{
    public interface INeed<in TContext> where TContext : IActorContext
    {
        float Amount(TContext context);
        bool IsAccomplished(TContext context);
    }
}