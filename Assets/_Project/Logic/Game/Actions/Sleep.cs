using System;
using _Project.Game.Domain;
using Cysharp.Threading.Tasks;
using RH_Modules.Utilities.Extensions;
using UnityEngine;

namespace _Project.Game.Actions
{
    public class Sleep : AI.Core.Action<NpcContext, WorldContext>
    {
        public override event Action OnComplete;
        
        protected override bool CanApplyAction(NpcContext context, WorldContext world) => 
            !context.Energy.ApproximatelyEqual(1f);

        protected override async void RunAction(NpcContext context, WorldContext world)
        {
            while (!context.FoodEnergy.ApproximatelyEqual(1f) && context.TargetFood.IsExist)
            {
                float delta = context.SleepSpeed * Time.deltaTime;
                context.Energy = Mathf.Min(context.Energy + delta, 1f);

                await UniTask.Yield();
            }
            
            OnComplete?.Invoke();
        }

        protected override float ApplyActionInstant(NpcContext context, WorldContext world)
        {
            throw new NotImplementedException();
        }
    }
}