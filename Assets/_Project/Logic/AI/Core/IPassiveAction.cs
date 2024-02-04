namespace _Project.AI.Core
{
    public interface IPassiveAction
    {
        bool CanApply(IStats forStats);
        void Execute(IStats forStats);
    }
}