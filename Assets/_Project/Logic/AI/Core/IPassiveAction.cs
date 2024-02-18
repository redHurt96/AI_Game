namespace _Project.AI.Core
{
    public interface IPassiveAction
    {
        bool CanApply(IActorContext actor, IWorldContext world);
        void Apply(IActorContext actor, IWorldContext world, float delta);
    }
}