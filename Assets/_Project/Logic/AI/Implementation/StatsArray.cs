using System.Collections.Generic;
using System.Linq;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    public class StatsArray : IStatsArray
    {
        private readonly List<IStat> _stats;

        public StatsArray(params IStat[] stats) => 
            _stats = stats.ToList();

        public void Apply(IActorAction action)
        {
            while (!action.IsComplete(this))
                action.Execute(this);
        }

        public IStatsArray Copy() => 
            new StatsArray(_stats.Select(x => x.Clone()).ToArray());

        public T Get<T>() where T : IStat => 
            (T)_stats.Find(x => x.GetType() == typeof(T));
    }
}