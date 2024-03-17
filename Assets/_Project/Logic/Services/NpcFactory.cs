using _Project.AI.Implementation;
using _Project.Game.Actions;
using _Project.Game.Domain;
using _Project.Game.Needs;
using _Project.Game.PassiveActions;
using _Project.Game.Presentation;
using _Project.Infrastructure;
using UnityEngine;
using static UnityEngine.Object;
using static UnityEngine.Quaternion;
using static UnityEngine.Random;
using static UnityEngine.Resources;

namespace _Project.Services
{
    public class NpcFactory
    {
        private readonly FoodsRepository _foodsRepository;
        private readonly Repository<Actor<Character>> _charactersRepository;

        public NpcFactory(FoodsRepository foodsRepository, Repository<Actor<Character>> charactersRepository)
        {
            _foodsRepository = foodsRepository;
            _charactersRepository = charactersRepository;
        }

        public void Create()
        {
            Vector3 position = new(Range(-15f, 15f), 0f, Range(-15f, 15f));
            NpcView view = Instantiate(Load<NpcView>("Npc"), position, identity);
            Character context = new(1f, 1f, _foodsRepository, view.GetComponent<MoveComponent>());
            Actor<Character> actor = new(
                new() { new Eat(), new Sleep(), new FindFood(), new GoToFood() },
                new() { new SpendEnergy(), new SpendFoodEnergy() },
                new() { new Energy(), new Hunger(), new WasteTime() },
                context);

            view.Setup(context);
            _charactersRepository.Register(actor);
        }
    }
}
