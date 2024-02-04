namespace _Project.AI.Core
{
    public interface IBehaviourAction
    {
        bool IsComplete(IStats withStats);
        void Execute(IStats forStats);
        void ApplyFull(IStats final);
    }
}