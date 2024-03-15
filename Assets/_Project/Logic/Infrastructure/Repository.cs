using System;
using System.Collections.Generic;
using RH_Modules.Utilities.Extensions;

namespace _Project.Infrastructure
{
    public class Repository<T>
    {
        private readonly Dictionary<Guid, T> _items = new();

        public void Register(Guid id, T item) => 
            _items.Add(id, item);

        public void ForEach(Action<T> action) => 
            _items.Values.ForEach(action);
    }
}