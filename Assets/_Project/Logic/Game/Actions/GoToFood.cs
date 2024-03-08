using _Project.AI.Core;
using _Project.Game.Domain;
using UnityEngine;
using static UnityEngine.Time;
using static UnityEngine.Vector3;

namespace _Project.Game.Actions
{
    public class GoToFood : IAction<NpcContext>, ILongAction<NpcContext>
    {
        public bool CanApply(NpcContext context) =>
            context.HasTargetFood
            && context.IsAwake;

        public bool IsComplete(NpcContext context) => 
            context.CloseEnoughToFood;

        public void Execute(NpcContext context) =>
            context.Position.Value = MoveTowards(
                context.Position.Value,
                GetTargetPoint(context),
                context.MoveSpeed * deltaTime);

        public void ApplyResult(NpcContext context) => 
            context.Position.Value = GetTargetPoint(context);

        private Vector3 GetTargetPoint(NpcContext context)
        {
            Vector3 directionFromFoodToPlayer = (context.Position.Value - context.TargetFood.Position).normalized;
            return context.TargetFood.Position + directionFromFoodToPlayer * context.MoveStoppingDistance;
        }
    }
}