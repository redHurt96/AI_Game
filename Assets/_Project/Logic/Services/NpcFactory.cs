using _Project.AI.Implementation;
using _Project.Game.Actions;
using _Project.Game.Domain;
using _Project.Game.Needs;
using _Project.Game.PassiveActions;
using _Project.Presentation;
using static UnityEngine.Object;
using static UnityEngine.Resources;
using static UnityEngine.Vector3;

namespace _Project.Services
{
    public class NpcFactory
    {
        public (Actor<NpcContext> actor, NpcView view) Create(FoodsRepository foodsRepository)
        {
            NpcContext context = new(1f, 1f, zero, foodsRepository);
            Actor<NpcContext> actor = new(
                new() { new Eat(), new Sleep(), new FindFood(), new GoToFood(), new Idle() },
                new() { new SpendEnergy(), new SpendFoodEnergy() },
                new() { new Energy(), new Hunger(), new WasteTime() },
                context);

            NpcView view = Instantiate(Load<NpcView>("Npc"));
            view.Setup(context);
            return new(actor, view);
        }
    }
}
