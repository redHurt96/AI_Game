using System;
using System.Collections.Generic;

namespace _Project.Infrastructure
{
    public class Repository<T>
    {
        private readonly List<T> _items = new();

        public void Register(T item) => 
            _items.Add(item);

        public void Unregister(T item) => 
            _items.Remove(item);

        public void ForEach(Action<T> action) => 
            _items.ForEach(action);
    }
}