using _Project.AI.Core;

namespace _Project.AI.Game
{
    public class Fullness : IStat
    {
        public float Value;
        
        public IStat Clone() =>
            new Fullness
            {
                Value = Value,
            };
    }
}