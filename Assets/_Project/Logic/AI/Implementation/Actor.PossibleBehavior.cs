using System.Collections.Generic;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    public partial class Actor<TContext> where TContext : IActorContext
    {
        private readonly struct PossibleBehavior
        {
            public bool HasActions => Actions is { Count: > 0 };
            public bool CanAccomplishNeed => _need.IsAccomplished(Context);

            public readonly Queue<IAction<TContext>> Actions;
            public readonly TContext Context;
            
            private readonly INeed<TContext> _need;

            public PossibleBehavior(INeed<TContext> need, TContext context)
            {
                _need = need;
                Context = context;
                Actions = new();
            }

            public PossibleBehavior(
                INeed<TContext> need, 
                TContext context,
                Queue<IAction<TContext>> actions)
                : this(need, context) =>
                Actions = actions;
        }
    }
}