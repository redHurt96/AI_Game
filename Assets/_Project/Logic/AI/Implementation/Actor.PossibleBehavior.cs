using System.Collections.Generic;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    public partial class Actor
    {
        private readonly struct PossibleBehavior
        {
            public bool HasActions => Actions is { Count: > 0 };
            public bool CanAccomplishNeed => _need.IsAccomplished(Context, World);

            public readonly Queue<IAction> Actions;
            public readonly IActorContext Context;
            public readonly IWorldContext World;
            
            private readonly INeed _need;

            public PossibleBehavior(INeed need, IActorContext context, IWorldContext world)
            {
                _need = need;
                Context = context;
                World = world;
                Actions = new();
            }

            public PossibleBehavior(
                INeed need, 
                IActorContext context, 
                IWorldContext world, 
                Queue<IAction> actions)
                : this(need, context, world) =>
                Actions = actions;
        }
    }
}