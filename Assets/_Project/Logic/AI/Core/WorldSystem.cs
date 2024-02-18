namespace _Project.AI.Core
{
    public abstract class WorldSystem<T> : IWorldSystem
        where T : IWorldContext
    {
        public void Tick(IWorldContext world) => 
            Tick((T)world);

        protected abstract void Tick(T world);
    }
}