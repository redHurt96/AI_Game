using System;

namespace _Project.AI.Core
{
    public abstract class Action<TContext, TWorld> : IAction
        where TContext : IActorContext
        where TWorld : IWorldContext
    {
        public abstract event Action OnComplete;
        
        public bool CanApply(IActorContext context, IWorldContext world) =>  
            CanApplyAction((TContext)context, (TWorld)world);

        public void Run(IActorContext context, IWorldContext world) => 
            RunAction((TContext)context, (TWorld)world);

        public float ApplyInstant(IActorContext context, IWorldContext world) => 
            ApplyActionInstant( (TContext)context, (TWorld)world);

        protected abstract bool CanApplyAction(TContext context, TWorld world);
        protected abstract void RunAction(TContext context, TWorld world);
        protected abstract float ApplyActionInstant(TContext context, TWorld world);
    }
}