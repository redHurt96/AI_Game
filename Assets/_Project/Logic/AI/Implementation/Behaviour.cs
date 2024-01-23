using System.Collections.Generic;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    public class Behaviour : IBehaviour
    {
        public bool Completed => _actions.Count == 0;
        
        private readonly Queue<IActorAction> _actions;

        public Behaviour(Queue<IActorAction> actions) => 
            _actions = actions;

        public void Execute(IStatsArray forStats)
        {
            _actions.Peek().Execute(forStats);

            if (_actions.Peek().IsComplete(forStats))
                _actions.Dequeue();
        }
    }
}