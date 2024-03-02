using _Project.AI.Implementation;
using _Project.Game.Actions;
using _Project.Game.Domain;
using _Project.Game.Needs;
using _Project.Game.PassiveActions;
using _Project.Presentation;
using UnityEngine;

namespace _Project.Services
{
    public class NpcFactory
    {
        public (Actor actor, NpcView view) Create(WorldContext worldContext)
        {
            NpcContext context = new(true, false, .5f, .8f, Vector3.zero);
            Actor actor = new(
                new() { new Eat(), new Sleep(), new FindFood(), new GoToFood() },
                new() { new SpendEnergy(), new SpendFoodEnergy() },
                new() { new Energy(), new Hunger() },
                worldContext,
                context);

            NpcView view = Object.Instantiate(Resources.Load<NpcView>("Npc"));
            view.Setup(context);
            return new(actor, view);
        }
    }
}
