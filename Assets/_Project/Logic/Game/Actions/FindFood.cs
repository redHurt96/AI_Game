using System;
using _Project.Game.Domain;
using Cysharp.Threading.Tasks;

namespace _Project.Game.Actions
{
    public class FindFood : AI.Core.Action<NpcContext, WorldContext>
    {
        public override event Action OnComplete;

        protected override bool CanApply(NpcContext context, WorldContext world) => 
            world.Foods.Any
            && context.IsAwake;

        protected override async void Apply(NpcContext context, WorldContext world)
        {
            await UniTask.WaitUntil(() => world.Foods.Any);
            
            context.TargetFood = world.Foods.GetClosest(context.Position);
            OnComplete?.Invoke();
        }

        protected override float GetApplyTime(NpcContext context, WorldContext world) => 
            0f;

        protected override void ApplyResult(NpcContext context, WorldContext world) => 
            context.TargetFood = world.Foods.GetClosest(context.Position);
    }
}