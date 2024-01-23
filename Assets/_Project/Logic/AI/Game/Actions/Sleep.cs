using _Project.AI.Core;
using _Project.AI.Game.Stats;
using UnityEngine;

namespace _Project.AI.Game.Actions
{
    public class Sleep : IActorAction
    {
        public bool IsComplete(IStatsArray forStats) => 
            forStats.Get<Energy>().Value > 90f;

        public void Execute(IStatsArray forStats)
        {
            forStats.Get<Energy>().Value += Time.deltaTime * 10;
            forStats.Get<Fullness>().Value -= Time.deltaTime * 9;
        }
    }
}
