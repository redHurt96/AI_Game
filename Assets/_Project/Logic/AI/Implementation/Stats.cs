using System.Collections.Generic;
using System.Linq;
using _Project.AI.Core;

namespace _Project.AI.Implementation
{
    public class Stats : IStats
    {
        private readonly List<IStat> _stats;

        public Stats(params IStat[] stats) => 
            _stats = stats.ToList();

        public IStats Copy() => 
            new Stats(_stats.Select(x => x.Clone()).ToArray());

        public T Get<T>() where T : IStat => 
            (T)_stats.Find(x => x.GetType() == typeof(T));
    }
}