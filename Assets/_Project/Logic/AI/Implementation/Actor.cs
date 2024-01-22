using System.Collections.Generic;
using System.Linq;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    public class Actor : IActor
    {
        private IBehaviour _behavior;

        private List<IActorAction> _actions = new();
        private List<INeed> _needs = new();
        private List<IStat> _stats = new();

        public void Act()
        {
            if (_behavior == null || _behavior.Completed)
                _behavior ??= SelectBehaviour();

            _behavior.Execute();
        }

        private IBehaviour SelectBehaviour()
        {
            INeed biggest = _needs.OrderByDescending(x => x.Amount()).First();
            List<IBehaviourPath> possiblePaths = new();

            while (possiblePaths.All(x => !x.CanAchieveGoal))
            {

            }

            return null;
        }
    }
}
