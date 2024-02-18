namespace _Project.AI.Core
{
    public interface IWorld
    {
        IWorldContext Context { get; }
        void Tick(float delta);
        IWorld Copy();
    }
}
