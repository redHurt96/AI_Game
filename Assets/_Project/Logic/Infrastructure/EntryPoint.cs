using _Project.AI.Core;
using _Project.AI.Game;
using _Project.AI.Game.Actions;
using _Project.AI.Game.Needs;
using _Project.AI.Game.PassiveActions;
using _Project.AI.Game.Stats;
using _Project.AI.Implementation;
using Zenject;

namespace _Project.Infrastructure
{
    public class EntryPoint : IInitializable, ITickable
    {
        private IActor _actor;

        public void Initialize() =>
            _actor = new Actor(new()
                {
                    new Hunger(),
                    new Cheerfulness(),
                },
                new()
                {
                    new Eat(),
                    new Sleep()
                },
                new Stats(
                    new Energy(), 
                    new Fullness(),
                    new AwakeState()),
                new()
                {
                    new SpendEnergy(),
                    new SpendFullness(),
                });

        public void Tick() => 
            _actor.Act();
    }
}