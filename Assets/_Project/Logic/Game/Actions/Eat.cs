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
        
        protected override bool CanApplyAction(NpcContext context, WorldContext world) => 
            context.HasTargetFood 
            && !context.FoodEnergy.ApproximatelyEqual(1f);

        protected override async void RunAction(NpcContext context, WorldContext world)
        {
            while (!context.FoodEnergy.ApproximatelyEqual(1f) && context.TargetFood.IsExist)
            {
                float delta = context.EatSpeed * deltaTime;
                context.FoodEnergy = Min(context.FoodEnergy + delta, 1f);
                context.TargetFood.FoodEnergy = Max(context.TargetFood.FoodEnergy - delta, 0f);

                await UniTask.Yield();
            }

            if (!context.TargetFood.IsExist)
            {
                world.Foods.Remove(context.TargetFood);
                context.TargetFood = default;
            }
            
            OnComplete?.Invoke();
        }

        protected override float ApplyActionInstant(NpcContext context, WorldContext world)
        {
            float delta = Min(context.TargetFood.FoodEnergy, 1f - context.FoodEnergy);
            float time = delta / deltaTime;

            context.FoodEnergy += delta;
            context.TargetFood.FoodEnergy -= delta;
            
            if (!context.TargetFood.IsExist)
            {
                world.Foods.Remove(context.TargetFood);
                context.TargetFood = default;
            }

            return time;
        }
    }
}
