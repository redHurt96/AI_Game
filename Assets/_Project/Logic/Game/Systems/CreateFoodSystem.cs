using _Project.AI.Core;
using _Project.Game.Domain;

namespace _Project.Game.Systems
{
    public class CreateFoodSystem : WorldSystem<WorldContext>
    {
        protected override void Tick(WorldContext world) => 
            world.FoodSpawner.Accumulate();
    }
}
