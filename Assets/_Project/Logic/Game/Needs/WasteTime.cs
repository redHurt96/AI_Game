using _Project.AI.Core;
using _Project.Game.Domain;

namespace _Project.Game.Needs
{
    public class WasteTime : INeed<NpcContext>
    {
        public float Amount(NpcContext context) => 
            0.01f;

        public bool IsAccomplished(NpcContext context) => 
            true;
    }
}