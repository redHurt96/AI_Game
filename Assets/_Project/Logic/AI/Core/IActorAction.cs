namespace _Project.AI.Core
{
    public interface IActorAction
    {
        bool IsComplete(IStatsArray forStats);
        void Execute(IStatsArray forStats);
    }
}