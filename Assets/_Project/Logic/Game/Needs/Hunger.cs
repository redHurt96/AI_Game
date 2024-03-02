using _Project.AI.Core;
using _Project.Game.Domain;
using RH_Modules.Utilities.Extensions;

namespace _Project.Game.Needs
{
    public class Hunger : Need<NpcContext, WorldContext>
    {
        private const float THRESHOLD = .25f;
        
        protected override bool ShouldWorriedAbout(NpcContext context, WorldContext world) => 
            Amount(context, world) > THRESHOLD;
        
        protected override float Amount(NpcContext context, WorldContext world) => 
            1f - context.FoodEnergy.Value;

        protected override bool IsNeedAccomplished(NpcContext context, WorldContext world) => 
            context.FoodEnergy.Value.ApproximatelyEqual(1f);
    }
}