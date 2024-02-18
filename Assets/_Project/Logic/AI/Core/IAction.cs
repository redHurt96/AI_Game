using System;

namespace _Project.AI.Core
{
    public interface IAction
    {
        event Action OnComplete;
        bool CanApply(IActorContext context, IWorldContext world);
        void Apply(IActorContext context, IWorldContext world);
        void StartApply(IActorContext context, IWorldContext world);
        float GetApplyTime(IActorContext context, IWorldContext world);
        void ApplyResult(IActorContext context, IWorldContext world);
    }
}