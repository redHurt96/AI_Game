using _Project.AI.Implementation;
using _Project.Game.Actions;
using _Project.Game.Domain;
using _Project.Game.Needs;
using _Project.Game.PassiveActions;
using _Project.Game.Presentation;
using _Project.Presentation;
using static UnityEngine.Object;
using static UnityEngine.Resources;

namespace _Project.Services
{
    public class NpcFactory
    {
        public (Actor<Character> actor, NpcView view) Create(FoodsRepository foodsRepository)
        {
            NpcView view = Instantiate(Load<NpcView>("Npc"));
            
            Character context = new(1f, 1f, foodsRepository, view.GetComponent<MoveComponent>());
            Actor<Character> actor = new(
                new() { new Eat(), new Sleep(), new FindFood(), new GoToFood() },
                new() { new SpendEnergy(), new SpendFoodEnergy() },
                new() { new Energy(), new Hunger(), new WasteTime() },
                context);

            view.Setup(context);
            return new(actor, view);
        }
    }
}
