using _Project.AI.Implementation;
using _Project.Game.Domain;
using _Project.Game.Systems;
using _Project.Presentation;
using _Project.Services;
using Zenject;
using static UnityEngine.Time;

namespace _Project.Infrastructure
{
    public class EntryPoint : IInitializable, ITickable
    {
        private readonly NpcFactory _npcFactory;
        private CreateFoodSystem _createFoodSystem;
        private (Actor actor, NpcView view) _actorTuple;

        public EntryPoint(NpcFactory npcFactory) => 
            _npcFactory = npcFactory;

        public void Initialize()
        {
            FoodsRepository foodsRepository = new(new());
            WorldContext worldContext = new(foodsRepository, new(foodsRepository));
            _createFoodSystem = new(worldContext);
            _actorTuple = _npcFactory.Create(worldContext);
        }

        public void Tick()
        {
            _createFoodSystem.Tick();
            _actorTuple.actor.Act(deltaTime);
        } 
    }
}