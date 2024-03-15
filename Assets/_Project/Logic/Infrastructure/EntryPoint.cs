using _Project.AI.Implementation;
using _Project.Game.Domain;
using _Project.Services;
using UnityEngine;
using Zenject;
using static UnityEngine.Time;

namespace _Project.Infrastructure
{
    public class EntryPoint : ITickable
    {
        private readonly FoodSpawner _foodSpawner;
        private readonly NpcFactory _npcFactory;
        private readonly Repository<Actor<Character>> _repository;

        public EntryPoint(FoodSpawner foodSpawner, NpcFactory npcFactory, Repository<Actor<Character>> repository)
        {
            _foodSpawner = foodSpawner;
            _npcFactory = npcFactory;
            _repository = repository;
        }

        public void Tick()
        {
            _foodSpawner.Tick();
            _repository.ForEach(x => x.Act(deltaTime));

            if (Input.GetKeyDown(KeyCode.Space))
                _npcFactory.Create();
        } 
    }
}