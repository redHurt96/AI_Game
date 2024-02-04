using System.Collections.Generic;
using System.Linq;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    public class Actor : IActor
    {
        private IBehaviour _behavior;

        private readonly List<IBehaviourAction> _actions;
        private readonly List<INeed> _needs;
        private readonly IStats _stats;
        private readonly List<IPassiveAction> _passiveActions;

        public Actor(List<INeed> needs, List<IBehaviourAction> actions, IStats stats, List<IPassiveAction> passiveActions)
        {
            _actions = actions;
            _needs = needs;
            _stats = stats;
            _passiveActions = passiveActions;
        }

        public void Act()
        {
            if (_behavior == null || _behavior.Completed)
                _behavior = SelectBehaviour();

            _behavior.Execute(_stats);
            _passiveActions.ForEach(x =>
            {
                if (x.CanApply(_stats))
                    x.Execute(_stats);
            });
        }

        private IBehaviour SelectBehaviour()
        {
            INeed biggest = _needs
                .OrderByDescending(x => x.Amount(_stats)) 
                .First();
            List<IBehaviourPath> possiblePaths = new()
            {
                new BehaviourPath(_stats, biggest),
            };

            while (possiblePaths.All(x => !x.CanAchieveGoal))
            {
                foreach (IBehaviourPath path in possiblePaths.ToArray())
                {
                    possiblePaths.Remove(path);

                    foreach (IBehaviourAction action in _actions)
                        possiblePaths.Add(new BehaviourPath(path, action));
                }
            }

            return possiblePaths
                .Find(x => x.CanAchieveGoal)
                .GetBehaviour();
        }
    }
}
