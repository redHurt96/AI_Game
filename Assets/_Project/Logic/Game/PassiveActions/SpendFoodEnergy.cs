using _Project.AI.Core;
using _Project.Game.Domain;
using static UnityEngine.Mathf;

namespace _Project.Game.PassiveActions
{
    public class SpendFoodEnergy : IPassiveAction<NpcContext>
    {
        public bool CanApply(NpcContext context) => 
            !context.IsEat;

        public void Apply(NpcContext context, float delta)
        {
            float result = Min(context.SpendFoodEnergySpeed * delta, context.FoodEnergy.Value);
            context.FoodEnergy.Value -= result;
        }
    }
}