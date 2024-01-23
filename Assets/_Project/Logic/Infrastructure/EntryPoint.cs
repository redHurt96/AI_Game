using _Project.AI.Game;
using _Project.AI.Game.Actions;
using _Project.AI.Game.Needs;
using _Project.AI.Game.Stats;
using _Project.AI.Implementation;
using Zenject;

namespace _Project.Infrastructure
{
    public class EntryPoint : IInitializable, ITickable
    {
        private Actor _actor;

        public void Initialize() =>
            _actor = new(new()
                {
                    new Hunger(),
                    new Cheerfulness()
                },
                new()
                {
                    new Eat(),
                    new Sleep()
                },
                new StatsArray(
                    new Energy(), 
                    new Fullness()));

        public void Tick() => 
            _actor.Act();
    }
}