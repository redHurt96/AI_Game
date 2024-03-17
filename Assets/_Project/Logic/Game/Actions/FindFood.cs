using _Project.AI.Core;
using _Project.Game.Domain;

namespace _Project.Game.Actions
{
    public class FindFood : IAction<Character>
    {
        public bool CanApply(Character context) => 
            context.WorldFood.Any && !context.HasTargetFood;

        public void ApplyResult(Character context)
        {
            context.TargetFood = context.WorldFood.GetClosest(context.MoveComponent.Position);
            context.WorldFood.Remove(context.TargetFood);
        }
    }
}