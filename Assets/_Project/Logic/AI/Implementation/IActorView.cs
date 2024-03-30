using System.Collections.Generic;

namespace _Project.AI.Implementation
{
    public interface IActorView
    {
        public IEnumerable<string> Behavior { get; }
    }
}