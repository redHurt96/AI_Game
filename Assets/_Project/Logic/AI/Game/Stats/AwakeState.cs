using _Project.AI.Core;

namespace _Project.AI.Game.Stats
{
    public class AwakeState : IStat
    {
        public bool Value;
        
        public IStat Clone() =>
            new AwakeState
            {
                Value = Value,
            };
    }
}