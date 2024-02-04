using _Project.AI.Core;
using UnityEngine;

namespace _Project.AI.Game.PassiveActions
{
    public class SpendFullness : IPassiveAction
    {
        public bool CanApply(IStats forStats) => 
            true;

        public void Execute(IStats forStats) => 
            forStats.Get<Fullness>().Value -= Time.deltaTime;
    }
}