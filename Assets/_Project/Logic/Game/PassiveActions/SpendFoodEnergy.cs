using _Project.AI.Core;
using _Project.Game.Domain;
using static UnityEngine.Mathf;

namespace _Project.Game.PassiveActions
{
    public class SpendFoodEnergy : PassiveAction<NpcContext, WorldContext>
    {
        protected override bool CanApplyAction(NpcContext context, IWorldContext world) => 
            !context.IsEat;

        protected override void ApplyAction(NpcContext context, IWorldContext world, float delta)
        {
            float result = Min(context.SpendFoodEnergySpeed * delta, context.FoodEnergy);
            context.FoodEnergy -= result;
        }
    }
}