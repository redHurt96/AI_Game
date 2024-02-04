using System.Collections.Generic;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    public class Behaviour : IBehaviour
    {
        public bool Completed => _actions.Count == 0;
        
        private readonly Queue<IBehaviourAction> _actions;

        public Behaviour(Queue<IBehaviourAction> actions) => 
            _actions = actions;

        public void Execute(IStats forStats)
        {
            IBehaviourAction current = _actions.Peek();
            
            if (current is IEnterAction { IsStarted: false } enterAction)
                enterAction.Enter(forStats);
            
            current.Execute(forStats);

            if (current.IsComplete(forStats))
            {
                if (current is IExitAction exitAction)
                    exitAction.Exit(forStats);
                
                _actions.Dequeue();
            }
        }
    }
}