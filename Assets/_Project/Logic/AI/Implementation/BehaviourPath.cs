using System.Collections.Generic;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    public class BehaviourPath : IBehaviourPath
    {
        public bool CanAchieveGoal => IsGoalAchieved();
        
        private readonly IStatsArray _stats;
        private readonly Queue<IActorAction> _actions = new();
        private readonly INeed _need;

        public BehaviourPath(IStatsArray stats, INeed need)
        {
            _stats = stats;
            _need = need;
        }

        public BehaviourPath(IBehaviourPath origin, IActorAction action) 
            : this(((BehaviourPath)origin)._stats, ((BehaviourPath)origin)._need) =>
            _actions.Enqueue(action);

        public IBehaviour GetBehaviour() => 
            new Behaviour(_actions);

        private bool IsGoalAchieved()
        {
            IStatsArray final = _stats.Copy();

            foreach (IActorAction action in _actions)
                final.Apply(action);

            return _need.AchievedFrom(final);
        }
    }
}