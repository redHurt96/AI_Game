namespace _Project.AI.Core
{
    public interface IBehaviourPath
    {
        bool CanAchieveGoal { get; }
        IBehaviour GetBehaviour();
    }
}