using _Project.AI.Core;
using _Project.Game.Domain;

namespace _Project.Game.Actions
{
    public class GoToFood : ILongAction<Character>, IAction<Character>
    {
        public bool CanApply(Character context) =>
            context.HasTargetFood
            && context.IsAwake;

        public bool IsComplete(Character context) => 
            context.CloseEnoughToFood;

        public bool CanBreak(Character context) => 
            !context.HasTargetFood;

        public void Execute(Character context)
        {
            if (context.MoveComponent.Target != context.TargetFood.Position)
                context.MoveComponent.Move(context.TargetFood.Position);
        }

        public void ApplyResult(Character context) => 
            context.MoveComponent.Move(context.TargetFood.Position);
    }
}