using System;
using _Project.Game.Domain;
using Cysharp.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Time;
using static UnityEngine.Vector3;

namespace _Project.Game.Actions
{
    public class GoToFood : AI.Core.Action<NpcContext, WorldContext>
    {
        public override event Action OnComplete;
        
        protected override bool CanApply(NpcContext context, WorldContext world) =>
            context.HasTargetFood
            && context.IsAwake;

        protected override float GetApplyTime(NpcContext context, WorldContext world) => 
            context.DistanceToFood / context.MoveSpeed;

        protected override async void Apply(NpcContext context, WorldContext world)
        {
            Vector3 targetPoint = GetTargetPoint(context);
            
            while (!context.CloseEnoughToFood)
            {
                context.Position.Value = MoveTowards(
                    context.Position.Value,
                    targetPoint,
                    context.MoveSpeed * deltaTime);
                
                await UniTask.Yield();
            }
        }

        protected override void ApplyResult(NpcContext context, WorldContext world) => 
            context.Position.Value = GetTargetPoint(context);

        private Vector3 GetTargetPoint(NpcContext context)
        {
            Vector3 directionFromFoodToPlayer = (context.Position.Value - context.TargetFood.Position).normalized;
            return context.TargetFood.Position + directionFromFoodToPlayer * context.MoveStoppingDistance;
        }
    }
}