using _Project.AI.Core;
using _Project.Game.Domain;
using RH_Modules.Utilities.Extensions;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Game.Actions
{
    public class Sleep : IAction<Character>, ILongAction<Character>
    {
        public bool CanApply(Character context) =>
            context.Energy.Value < .8f
            && context.IsAwake;

        public bool IsComplete(Character context) => 
            context.Energy.Value.ApproximatelyEqual(1f);

        public void Execute(Character context)
        {
            context.IsAwake = false;
            float delta = context.Config.SleepSpeed * deltaTime;
            context.Energy.Value = Min(context.Energy.Value + delta, 1f);
        }

        public void ApplyResult(Character context)
        {
            context.Energy.Value = 1f;
            context.IsAwake = true;
        }
    }
}