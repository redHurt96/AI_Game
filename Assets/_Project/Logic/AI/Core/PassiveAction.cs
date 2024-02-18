 namespace _Project.AI.Core
{
    public abstract class PassiveAction<TContext, TWorld> : IPassiveAction
        where TContext : IActorContext
        where TWorld : IWorldContext
    {
        public bool CanApply(IActorContext actor, IWorldContext world) => 
            CanApplyAction((TContext)actor, (TWorld)world);

        public void Apply(IActorContext actor, IWorldContext world, float delta) => 
            ApplyAction((TContext)actor, (TWorld)world, delta);

        protected abstract bool CanApplyAction(TContext context, IWorldContext world);
        protected abstract void ApplyAction(TContext context, IWorldContext world, float delta);
    }
}