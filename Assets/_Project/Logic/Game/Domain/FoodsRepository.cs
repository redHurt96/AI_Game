using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Vector3;

namespace _Project.Game.Domain
{
    public class FoodsRepository
    {
        public bool Any => _foods.Any();
        
        private readonly List<Food> _foods;

        private FoodsRepository(List<Food> foods) => 
            _foods = foods;

        public FoodsRepository Copy() =>
            new(_foods
                .Select(x => x.Copy())
                .ToList());

        public Food GetClosest(Vector3 to) =>
            _foods
                .OrderBy(x => Distance(x.Position, to))
                .First();

        public void Add(Food food) => 
            _foods.Add(food);

        public void Remove(Food food) => 
            _foods.Remove(food);
    }
}