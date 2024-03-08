using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Game.Domain
{
    public class FoodsRepository
    {
        public readonly Guid ID = Guid.NewGuid();
        
        public bool Any => _foods.Any();
        
        private readonly List<Food> _foods;

        public FoodsRepository(List<Food> foods) => 
            _foods = foods;

        public FoodsRepository Copy() =>
            new(_foods
                .Select(x => x.Copy())
                .ToList());

        public Food GetClosest(Vector3 to) =>
            _foods
                .OrderBy(x => Vector3.Distance(x.Position, to))
                .First();

        public void Add(Food food) => 
            _foods.Add(food);

        public void Remove(Food food) => 
            _foods.Remove(food);
    }
}