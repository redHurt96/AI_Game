using _Project.AI.Core;
using _Project.Game.Domain;
using RH_Modules.Utilities.Extensions;
using UnityEngine;

namespace _Project.Game.Actions
{
    public class Idle : IAction<NpcContext>, ILongAction<NpcContext>
    {
        public bool CanApply(NpcContext context) => 
            true;

        public void ApplyResult(NpcContext context) => 
            context.ChillTimer = 1f;

        public bool IsComplete(NpcContext context) => 
            context.ChillTimer.ApproximatelyEqual(0f);

        public void Execute(NpcContext context) => 
            context.ChillTimer = Mathf.Max(context.ChillTimer - Time.deltaTime, 0f);
    }
}