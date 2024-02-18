using System;

namespace _Project.AI.Core
{
    public abstract class Action<TContext, TWorld> : IAction
        where TContext : IActorContext
        where TWorld : IWorldContext
    {
        public abstract event Action OnComplete;
        
        public bool CanApply(IActorContext context, IWorldContext world) =>  
            CanApply((TContext)context, (TWorld)world);

        public void Apply(IActorContext context, IWorldContext world) => 
            Apply((TContext)context, (TWorld)world);

        public void StartApply(IActorContext context, IWorldContext world) => 
            StartApply((TContext)context, (TWorld)world);

        public float GetApplyTime(IActorContext context, IWorldContext world) => 
            GetApplyTime((TContext)context, (TWorld)world);

        public void ApplyResult(IActorContext context, IWorldContext world) => 
            ApplyResult( (TContext)context, (TWorld)world);

        protected abstract bool CanApply(TContext context, TWorld world);
        protected virtual void StartApply(TContext context, TWorld world) {}
        protected abstract void Apply(TContext context, TWorld world);
        protected abstract float GetApplyTime(TContext context, TWorld world);
        protected abstract void ApplyResult(TContext context, TWorld world);
    }
}