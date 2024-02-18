using _Project.AI.Core;

namespace _Project.Game.Domain
{
    public class WorldContext : IWorldContext
    {
        public FoodsRepository Foods;
        public FoodSpawner FoodSpawner;

        public WorldContext(FoodsRepository foods, FoodSpawner foodSpawner)
        {
            Foods = foods;
            FoodSpawner = foodSpawner;
        }

        public IWorldContext Copy()
        {
            FoodsRepository foodsRepository = Foods.Copy();
            return new WorldContext(
                Foods = foodsRepository,
                FoodSpawner = FoodSpawner.Copy(foodsRepository));
        }
    }
}