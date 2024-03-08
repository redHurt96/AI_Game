using _Project.AI.Implementation;
using _Project.Game.Domain;
using _Project.Presentation;
using _Project.Services;
using Zenject;
using static UnityEngine.Time;

namespace _Project.Infrastructure
{
    public class EntryPoint : IInitializable, ITickable
    {
        private readonly NpcFactory _npcFactory;
        private FoodSpawner _foodSpawner;
        private (Actor<NpcContext> actor, NpcView view) _actorTuple;

        public EntryPoint(NpcFactory npcFactory) => 
            _npcFactory = npcFactory;

        public void Initialize()
        {
            FoodsRepository foodsRepository = new(new());
            _foodSpawner = new(foodsRepository);
            _actorTuple = _npcFactory.Create(foodsRepository);
        }

        public void Tick()
        {
            _foodSpawner.Tick();
            _actorTuple.actor.Act(deltaTime);
        } 
    }
}