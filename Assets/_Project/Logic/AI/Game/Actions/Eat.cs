using _Project.AI.Core;
using UnityEngine;

namespace _Project.AI.Game.Actions
{
    public class Eat : IBehaviourAction
    {
        public bool IsComplete(IStats withStats) => 
            withStats.Get<Fullness>().Value > 90f;

        public void Execute(IStats forStats) => 
            forStats.Get<Fullness>().Value += Time.deltaTime * 10;

        public void ApplyFull(IStats final) => 
            final.Get<Fullness>().Value = 100;
    }
}