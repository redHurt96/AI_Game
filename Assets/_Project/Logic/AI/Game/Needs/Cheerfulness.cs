using _Project.AI.Core;
using _Project.AI.Game.Stats;

namespace _Project.AI.Game.Needs
{
    public class Cheerfulness : INeed
    {
        public float Amount(IStatsArray stats) => 
            100 - stats.Get<Energy>().Value;

        public bool AchievedFrom(IStatsArray stats) => 
            stats.Get<Energy>().Value > 90f;
    }
}