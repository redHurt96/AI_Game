namespace _Project.AI.Core
{
    public interface IStats
    {
        IStats Copy();
        T Get<T>() where T : IStat;
    }
}