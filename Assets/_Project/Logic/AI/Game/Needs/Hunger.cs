using _Project.AI.Core;

namespace _Project.AI.Game.Needs
{
    public class Hunger : INeed
    {
        public float Amount(IStatsArray stats) => 
            100 - stats.Get<Fullness>().Value;

        public bool AchievedFrom(IStatsArray stats) => 
            stats.Get<Fullness>().Value > 90f;
    }
}
