using _Project.AI.Core;
using _Project.Game.Domain;
using static UnityEngine.Mathf;

namespace _Project.Game.PassiveActions
{
    public class SpendEnergy : IPassiveAction<Character>
    {
        public bool CanApply(Character context) => 
            context.IsAwake;

        public void Apply(Character context, float delta)
        {
            float result = Min(context.Config.SpendEnergySpeed * delta, context.Energy.Value);
            context.Energy.Value -= result;
        }
    }
}
