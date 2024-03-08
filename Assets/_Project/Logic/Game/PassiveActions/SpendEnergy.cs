using _Project.AI.Core;
using _Project.Game.Domain;
using static UnityEngine.Mathf;

namespace _Project.Game.PassiveActions
{
    public class SpendEnergy : IPassiveAction<NpcContext>
    {
        public bool CanApply(NpcContext context) => 
            context.IsAwake;

        public void Apply(NpcContext context, float delta)
        {
            float result = Min(context.SpendEnergySpeed * delta, context.Energy.Value);
            context.Energy.Value -= result;
        }
    }
}
