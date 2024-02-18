using System;

namespace _Project.AI.Core
{
    public interface IAction
    {
        event Action OnComplete;
        bool CanApply(IActorContext context, IWorldContext world);
        void Run(IActorContext context, IWorldContext world);
        float ApplyInstant(IActorContext context, IWorldContext world);
    }
}