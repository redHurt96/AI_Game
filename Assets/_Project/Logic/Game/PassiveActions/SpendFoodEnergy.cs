using _Project.AI.Core;
using _Project.Game.Domain;
using static UnityEngine.Mathf;

namespace _Project.Game.PassiveActions
{
    public class SpendFoodEnergy : IPassiveAction<Character>
    {
        public bool CanApply(Character context) => 
            !context.IsEat;

        public void Apply(Character context, float delta)
        {
            float result = Min(context.Config.SpendFoodEnergySpeed * delta, context.FoodEnergy.Value);
            context.FoodEnergy.Value -= result;
        }
    }
}