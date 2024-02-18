using System;
using System.Collections.Generic;

namespace _Project.AI.Extensions
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T obj in source)
                action(obj);

            return source;
        }
    }
}