using System.Collections.Generic;
using _Project.AI.Core;
using RH_Modules.Utilities.Extensions;

namespace _Project.AI.Implementation
{
    public class BehaviourPath : IBehaviourPath
    {
        public bool CanAchieveGoal => IsGoalAchieved();
        
        private readonly IStats _stats;
        private readonly Queue<IBehaviourAction> _actions = new();
        private readonly INeed _need;

        public BehaviourPath(IStats stats, INeed need)
        {
            _stats = stats;
            _need = need;
        }

        public BehaviourPath(IBehaviourPath origin, IBehaviourAction action) 
            : this(((BehaviourPath)origin)._stats, ((BehaviourPath)origin)._need)
        {
            ((BehaviourPath)origin)._actions
                .ForEach(x => _actions.Enqueue(x));
            
            _actions.Enqueue(action);
        }

        public IBehaviour GetBehaviour() => 
            new Behaviour(_actions);

        private bool IsGoalAchieved()
        {
            IStats final = _stats.Copy();
            _actions.ForEach(x => x.ApplyFull(final));
            return _need.AchievedFrom(final);
        }
    }
}