namespace _Project.AI.Core
{
    public interface IStatsArray
    {
        void Apply(IActorAction action);
        IStatsArray Copy();
        T Get<T>() where T : IStat;
    }
}