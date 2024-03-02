namespace _Project.AI.Core
{
    public abstract class Need<TContext, TWorld> : INeed
        where TContext : IActorContext
        where TWorld : IWorldContext
    {
        public bool ShouldWorriedAbout(IActorContext context, IWorldContext world) => 
            ShouldWorriedAbout((TContext)context, (TWorld)world);

        public float Amount(IActorContext context, IWorldContext world) => 
            Amount((TContext)context, (TWorld)world);

        public bool IsAccomplished(IActorContext context, IWorldContext world) => 
            IsNeedAccomplished((TContext)context, (TWorld)world);

        protected abstract bool ShouldWorriedAbout(TContext context, TWorld world);
        protected abstract float Amount(TContext context, TWorld world);
        protected abstract bool IsNeedAccomplished(TContext context, TWorld world);
    }
}