using Zenject;

namespace _Project.Infrastructure
{
    public class EntryPoint : IInitializable, ITickable
    {
        private readonly SystemsHandler _systemsHandler;

        public EntryPoint(SystemsHandler systemsHandler)
        {
            _systemsHandler = systemsHandler;
        }

        public void Initialize()
        {
            
        }

        public void Tick() {} 
    }
}