using System;
using _Project.Game.Domain;
using Cysharp.Threading.Tasks;
using RH_Modules.Utilities.Extensions;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Game.Actions
{
    public class Eat : AI.Core.Action<NpcContext, WorldContext>
    {
        public override event Action OnComplete;
        
        protected override bool CanApply(NpcContext context, WorldContext world) => 
            context.HasTargetFood 
            && !context.FoodEnergy.ApproximatelyEqual(1f)
            && context.IsAwake;

        protected override void StartApply(NpcContext context, WorldContext world)
        {
            base.StartApply(context, world);
            context.IsEat = true;
        }

        protected override async void Apply(NpcContext context, WorldContext world)
        {
            while (!context.FoodEnergy.ApproximatelyEqual(1f) && context.TargetFood.IsExist)
            {
                float delta = context.EatSpeed * deltaTime;
                context.FoodEnergy = Min(context.FoodEnergy + delta, 1f);
                context.TargetFood.FoodEnergy = Max(context.TargetFood.FoodEnergy - delta, 0f);

                await UniTask.Yield();
            }

            RemoveFood(context, world);
            OnComplete?.Invoke();
        }

        protected override float GetApplyTime(NpcContext context, WorldContext world)
        {
            float delta = CalculateDelta(context);
            float time = delta / context.EatSpeed;
            
            return time;
        }

        protected override void ApplyResult(NpcContext context, WorldContext world)
        {
            float delta = CalculateDelta(context);

            context.FoodEnergy += delta;
            context.TargetFood.FoodEnergy -= delta;
            context.IsEat = false;
            
            RemoveFood(context, world);
        }

        private static void RemoveFood(NpcContext context, WorldContext world)
        {
            world.Foods.Remove(context.TargetFood);
            context.TargetFood = default;
        }

        private static float CalculateDelta(NpcContext context)
        {
            float delta = Min(context.TargetFood.FoodEnergy, 1f - context.FoodEnergy);
            return delta;
        }
    }
}
