using _Project.AI.Core;
using _Project.Game.Domain;
using RH_Modules.Utilities.Extensions;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Game.Actions
{
    public class Sleep : IAction<NpcContext>, ILongAction<NpcContext>
    {
        public bool CanApply(NpcContext context) =>
            context.Energy.Value < .8f
            && context.IsAwake;

        public bool IsComplete(NpcContext context) => 
            context.Energy.Value.ApproximatelyEqual(1f);

        public void Execute(NpcContext context)
        {
            context.IsAwake = false;
            float delta = context.SleepSpeed * deltaTime;
            context.Energy.Value = Min(context.Energy.Value + delta, 1f);
        }

        public void ApplyResult(NpcContext context)
        {
            context.Energy.Value = 1f;
            context.IsAwake = true;
        }
    }
}