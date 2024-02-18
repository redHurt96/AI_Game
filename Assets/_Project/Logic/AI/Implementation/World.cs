using System.Collections.Generic;
using System.Linq;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    internal class World : IWorld
    {
        public IWorldContext Context { get; }

        private readonly List<IWorldSystem> _systems;
        private readonly List<IActor> _actors;

        public World(IWorldContext context, IEnumerable<IWorldSystem> systems, IEnumerable<IActor> actors)
        {
            Context = context;
            _systems = systems.ToList();
            _actors = actors.ToList();
        }

        public void Tick(float delta)
        {
            _systems.ForEach(x => x.Tick(this));
            _actors.ForEach(x => x.Act(delta));
        }

        public IWorld Copy() =>
            new World(
                Context.Copy(), 
                _systems,  
                _actors.Select(x => x.Copy()));
    }
}
