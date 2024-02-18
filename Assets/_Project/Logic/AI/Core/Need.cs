namespace _Project.AI.Core
{
    public abstract class Need<TContext, TWorld> : INeed
        where TContext : IActorContext
        where TWorld : IWorldContext
    {
        public float Amount(IActorContext context, IWorldContext world) => 
            GetAmount((TContext)context, (TWorld)world);

        public bool IsAccomplished(IActorContext context, IWorldContext world) => 
            IsNeedAccomplished((TContext)context, (TWorld)world);

        protected abstract float GetAmount(TContext context, TWorld world);
        protected abstract bool IsNeedAccomplished(TContext context, TWorld world);
    }
}