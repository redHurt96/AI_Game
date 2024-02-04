namespace _Project.AI.Core
{
    public interface INeed
    {
        float Amount(IStats stats);
        bool AchievedFrom(IStats stats);
    }
}