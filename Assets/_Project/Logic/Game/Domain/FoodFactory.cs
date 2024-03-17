using _Project.Presentation;
using UnityEngine;

namespace _Project.Game.Domain
{
    public class FoodFactory
    {
        private readonly FoodsRepository _foodsRepository;

        public FoodFactory(FoodsRepository foodsRepository) => 
            _foodsRepository = foodsRepository;
        
        public void Create()
        {
            Food food = new(new(Random.Range(-10, 10), 0f, Random.Range(-10, 10)));
            Object.Instantiate(Resources.Load<FoodView>("Food")).Setup(food);
            _foodsRepository.Add(food);
        }
    }
}