using _Project.AI.Core;
using _Project.Game.Domain;
using RH_Modules.Utilities.Extensions;

namespace _Project.Game.Needs
{
    public class Hunger : Need<NpcContext, WorldContext>
    {
        protected override float GetAmount(NpcContext context, WorldContext world) => 
            1f - context.FoodEnergy;

        protected override bool IsNeedAccomplished(NpcContext context, WorldContext world) => 
            context.FoodEnergy.ApproximatelyEqual(1f);
    }
}