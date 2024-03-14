using _Project.AI.Core;
using _Project.Game.Domain;
using RH_Modules.Utilities.Extensions;

namespace _Project.Game.Needs
{
    public class Energy : INeed<Character>
    {
        private const float THRESHOLD = .25f;
        
        public float Amount(Character context) =>
            context.Energy.Value < 1 - THRESHOLD
                ? 1f - context.Energy.Value
                : 0f;

        public bool IsAccomplished(Character context) => 
            context.Energy.Value.ApproximatelyEqual(1f);
    }
}
