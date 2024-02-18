using _Project.AI.Core;
using _Project.Game.Domain;
using static UnityEngine.Mathf;

namespace _Project.Game.PassiveActions
{
    public class SpendEnergy : PassiveAction<NpcContext, WorldContext>
    {
        protected override bool CanApplyAction(NpcContext context, IWorldContext world) => 
            context.IsAwake;

        protected override void ApplyAction(NpcContext context, IWorldContext world, float delta)
        {
            float result = Min(context.SpendEnergySpeed * delta, context.Energy);
            context.Energy -= result;
        }
    }
}
