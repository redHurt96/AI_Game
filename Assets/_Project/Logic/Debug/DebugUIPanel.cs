using _Project.Game.Domain;
using _Project.Services;
using DebugUI;
using Zenject;

namespace _Project.Debug
{
    public class DebugUIPanel : DebugUIBuilderBase
    {
        private NpcFactory _npcFactory;
        private FoodFactory _foodFactory;

        [Inject]
        private void Construct(NpcFactory npcFactory, FoodFactory foodFactory)
        {
            _foodFactory = foodFactory;
            _npcFactory = npcFactory;
        }
        
        protected override void Configure(IDebugUIBuilder builder)
        {
            builder.AddButton("Spawn character", () => _npcFactory.Create());
            builder.AddButton("Spawn food", () => _foodFactory.Create());
        }
    }
}
