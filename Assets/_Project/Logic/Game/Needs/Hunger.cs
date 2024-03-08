using _Project.AI.Core;
using _Project.Game.Domain;
using RH_Modules.Utilities.Extensions;

namespace _Project.Game.Needs
{
    public class Hunger : INeed<NpcContext>
    {
        private const float THRESHOLD = .25f;
        
        public float Amount(NpcContext context) =>
            context.Energy.Value < 1 - THRESHOLD
                ? 1f - context.FoodEnergy.Value
                : 0f;

        public bool IsAccomplished(NpcContext context) => 
            context.FoodEnergy.Value.ApproximatelyEqual(1f);
    }
}