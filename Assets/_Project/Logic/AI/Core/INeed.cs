namespace _Project.AI.Core
{
    public interface INeed
    {
        float Amount(IStatsArray stats);
        bool AchievedFrom(IStatsArray stats);
    }
}