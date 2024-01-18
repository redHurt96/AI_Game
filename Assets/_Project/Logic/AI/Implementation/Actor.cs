using System.Collections.Generic;
using System.Linq;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    public class Actor : IActor
    {
        private Queue<IActorAction> _behavior;

        private List<IActorAction> _actions = new();
        private List<INeed> _needs = new();
        private List<IStat> _stats = new();

        public void Act()
        {
            _behavior ??= SelectBehaviour();
            _behavior.Peek().Execute();

            if (_behavior.Peek().IsComplete)
                _behavior.Dequeue();
        }

        private Queue<IActorAction> SelectBehaviour()
        {
            INeed biggest = _needs.OrderByDescending(x => x.Value()).First();

            return null;
        }
    }
}
