using System;
using _Project.Game.Domain;
using Cysharp.Threading.Tasks;

namespace _Project.Game.Actions
{
    public class FindFood : AI.Core.Action<NpcContext, WorldContext>
    {
        public override event Action OnComplete;

        protected override bool CanApplyAction(NpcContext context, WorldContext world) => 
            world.Foods.Any;

        protected override async void RunAction(NpcContext context, WorldContext world)
        {
            await UniTask.WaitUntil(() => world.Foods.Any);
            
            context.TargetFood = world.Foods.GetClosest(context.Position);
            OnComplete?.Invoke();
        }

        protected override float ApplyActionInstant(NpcContext context, WorldContext world)
        {
            context.TargetFood = world.Foods.GetClosest(context.Position);
            return 0f;
        }
    }
}