using _Project.Game.Domain;
using Zenject;

namespace _Project.Game.Systems
{
    public class CreateFoodSystem : ITickable
    {
        private readonly WorldContext _world;

        public CreateFoodSystem(WorldContext world) => 
            _world = world;

        public void Tick() => 
            _world.FoodSpawner.Accumulate();
    }
}
