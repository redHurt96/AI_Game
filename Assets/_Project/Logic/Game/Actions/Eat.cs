using _Project.AI.Core;
using _Project.Game.Domain;
using RH_Modules.Utilities.Extensions;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Game.Actions
{
    public class Eat : IAction<NpcContext>, ILongAction<NpcContext>
    {
        public bool CanApply(NpcContext context) =>
            context.CloseEnoughToFood
            && context.FoodEnergy.Value > .8f;

        public bool IsComplete(NpcContext context) => 
            context.FoodEnergy.Value.ApproximatelyEqual(1f) && context.HasTargetFood;

        public void Execute(NpcContext context)
        {
            float delta = context.EatSpeed * deltaTime;
            
            context.IsEat = true;
            context.FoodEnergy.Value = Min(context.FoodEnergy.Value + delta, 1f);
        }

        public void ApplyResult(NpcContext context)
        {
            context.FoodEnergy.Value = 1f;
            context.IsEat = false;
            
            RemoveFood(context);
        }

        private static void RemoveFood(NpcContext context)
        {
            context.TargetFood.Destroy();
            context.WorldFood.Remove(context.TargetFood);
            context.TargetFood = default;
        }
    }
}
