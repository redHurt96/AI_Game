namespace _Project.AI.Core
{
    public interface ILongAction<in TContext> where TContext : IActorContext 
    {
        bool IsComplete(TContext context);
        void Execute(TContext context);
    }
}