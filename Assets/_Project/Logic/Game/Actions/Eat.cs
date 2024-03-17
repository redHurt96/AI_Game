using _Project.AI.Core;
using _Project.Game.Domain;
using RH_Modules.Utilities.Extensions;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Game.Actions
{
    public class Eat : IAction<Character>, ILongAction<Character>
    {
        public bool CanApply(Character context) =>
            context.CloseEnoughToFood
            && context.FoodEnergy.Value < .8f;

        public bool IsComplete(Character context) => 
            context.FoodEnergy.Value.ApproximatelyEqual(1f) && context.HasTargetFood;

        public void Execute(Character context)
        {
            float delta = context.EatSpeed * deltaTime;
            
            context.IsEat = true;
            context.FoodEnergy.Value = Min(context.FoodEnergy.Value + delta, 1f);
        }

        public void ApplyResult(Character context)
        {
            context.FoodEnergy.Value = 1f;
            context.IsEat = false;
            
            RemoveFood(context);
        }

        private static void RemoveFood(Character context)
        {
            context.TargetFood.Destroy();
            context.TargetFood = null;
        }
    }
}
