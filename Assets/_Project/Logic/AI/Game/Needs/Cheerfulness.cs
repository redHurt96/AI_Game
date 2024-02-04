using _Project.AI.Core;
using _Project.AI.Game.Stats;

namespace _Project.AI.Game.Needs
{
    public class Cheerfulness : INeed
    {
        public float Amount(IStats stats) => 
            100 - stats.Get<Energy>().Value;

        public bool AchievedFrom(IStats stats) => 
            stats.Get<Energy>().Value > 90f;
    }
}