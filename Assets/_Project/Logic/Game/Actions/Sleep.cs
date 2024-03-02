using System;
using _Project.Game.Domain;
using Cysharp.Threading.Tasks;
using RH_Modules.Utilities.Extensions;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Game.Actions
{
    public class Sleep : AI.Core.Action<NpcContext, WorldContext>
    {
        public override event Action OnComplete;
        
        protected override bool CanApply(NpcContext context, WorldContext world) => 
            !context.Energy.Value.ApproximatelyEqual(1f)
            && context.IsAwake;

        protected override void StartApply(NpcContext context, WorldContext world)
        {
            base.StartApply(context, world);
            context.IsAwake = false;
        }

        protected override async void Apply(NpcContext context, WorldContext world)
        {
            while (!context.FoodEnergy.Value.ApproximatelyEqual(1f) && context.HasTargetFood)
            {
                float delta = context.SleepSpeed * deltaTime;
                context.Energy.Value = Min(context.Energy.Value + delta, 1f);

                await UniTask.Yield();
            }
            
            OnComplete?.Invoke();
        }

        protected override float GetApplyTime(NpcContext context, WorldContext world)
        {
            float delta = 1f - context.Energy.Value;
            float time = delta / context.SleepSpeed;

            return time;
        }

        protected override void ApplyResult(NpcContext context, WorldContext world)
        {
            context.Energy.Value = 1f;
            context.IsAwake = true;
        }
    }
}