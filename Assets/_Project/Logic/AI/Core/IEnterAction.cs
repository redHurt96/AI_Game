namespace _Project.AI.Core
{
    public interface IEnterAction
    {
        bool IsStarted { get; }
        void Enter(IStats withStats);
    }
}