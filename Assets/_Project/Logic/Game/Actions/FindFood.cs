using _Project.AI.Core;
using _Project.Game.Domain;

namespace _Project.Game.Actions
{
    public class FindFood : IAction<NpcContext>
    {
        public bool CanApply(NpcContext context) => 
            context.WorldFood.Any && !context.HasTargetFood;

        public void ApplyResult(NpcContext context) => 
            context.TargetFood = context.WorldFood.GetClosest(context.Position.Value);
    }
}