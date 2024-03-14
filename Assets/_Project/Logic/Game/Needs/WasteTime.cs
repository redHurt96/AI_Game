using _Project.AI.Core;
using _Project.Game.Domain;

namespace _Project.Game.Needs
{
    public class WasteTime : INeed<Character>
    {
        public float Amount(Character context) => 
            0.01f;

        public bool IsAccomplished(Character context) => 
            true;
    }
}