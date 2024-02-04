using _Project.AI.Core;
using _Project.AI.Game.Stats;
using static UnityEngine.Time;

namespace _Project.AI.Game.Actions
{
    public class Sleep : IBehaviourAction, IEnterAction, IExitAction
    {
        public bool IsStarted { get; private set; }

        public bool IsComplete(IStats withStats) => 
            withStats.Get<Energy>().Value > 90f;

        public void Execute(IStats forStats) => 
            forStats.Get<Energy>().Value += deltaTime * 10;

        public void ApplyFull(IStats final) => 
            final.Get<Energy>().Value = 100;

        public void Enter(IStats withStats)
        {
            IsStarted = true;
            withStats.Get<AwakeState>().Value = true;
        }

        public void Exit(IStats withStats)
        {
            withStats.Get<AwakeState>().Value = false;
            IsStarted = false;
        }
    }
}
