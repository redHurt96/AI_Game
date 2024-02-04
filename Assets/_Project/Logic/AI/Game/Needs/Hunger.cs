using _Project.AI.Core;

namespace _Project.AI.Game.Needs
{
    public class Hunger : INeed
    {
        public float Amount(IStats stats) => 
            100 - stats.Get<Fullness>().Value;

        public bool AchievedFrom(IStats stats) => 
            stats.Get<Fullness>().Value > 90f;
    }
}
