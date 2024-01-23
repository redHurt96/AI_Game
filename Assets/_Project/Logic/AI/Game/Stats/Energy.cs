using _Project.AI.Core;

namespace _Project.AI.Game.Stats
{
    public class Energy : IStat
    {
        public float Value;
        
        public IStat Clone() =>
            new Energy
            {
                Value = Value,
            };
    }
}