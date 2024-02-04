using _Project.AI.Core;
using _Project.AI.Game.Stats;
using static UnityEngine.Time;

namespace _Project.AI.Game.PassiveActions
{
    public class SpendEnergy : IPassiveAction
    {
        public bool CanApply(IStats forStats) => 
            forStats.Get<AwakeState>().Value;

        public void Execute(IStats forStats) => 
            forStats.Get<Energy>().Value -= deltaTime;
    }
}