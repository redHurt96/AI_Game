using _Project.AI.Core;

namespace _Project.Game.Domain
{
    public class WorldContext : IWorldContext
    {
        public FoodsRepository Foods;

        public IWorldContext Copy() =>
            new WorldContext
            {
                Foods = Foods.Copy(),
            };
    }
}