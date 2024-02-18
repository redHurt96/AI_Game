using System.Collections.Generic;
using _Project.AI.Core;
using _Project.AI.Implementation;
using _Project.Game.Actions;
using _Project.Game.Domain;
using _Project.Game.Needs;
using _Project.Game.PassiveActions;
using _Project.Game.Systems;
using UnityEngine;
using Zenject;
using static UnityEngine.Time;

namespace _Project.Infrastructure
{
    public class EntryPoint : IInitializable, ITickable
    {
        private IWorld _world;

        public void Initialize()
        {
            FoodsRepository foodsRepository = new(new());
            WorldContext worldContext = new(foodsRepository, new(foodsRepository));
            _world = new World(
                worldContext,
                new[] { new CreateFoodSystem() },
                new[]
                {
                    new Actor(
                        new() { new Eat(), new Sleep(), new FindFood() },
                        new() { new SpendEnergy(), new SpendFoodEnergy() },
                        new() { new Energy(), new Hunger() },
                        worldContext,
                        new NpcContext(true, false, .5f, .8f, Vector3.zero))
                });
        }

        public void Tick()
        {
            _world.Tick(deltaTime); 
        } 
    }
}