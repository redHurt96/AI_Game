using _Project.Presentation;
using UnityEngine;
using Zenject;

namespace _Project.Game.Domain
{
    public class ManualFoodSpawner : ITickable
    {
        private readonly FoodsRepository _foodsRepository;

        public ManualFoodSpawner(FoodsRepository foodsRepository) => 
            _foodsRepository = foodsRepository;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.F))
                CreateFood();
        }

        private void CreateFood()
        {
            Food food = new(new(Random.Range(-10, 10), 0f, Random.Range(-10, 10)));
            Object.Instantiate(Resources.Load<FoodView>("Food")).Setup(food);
            _foodsRepository.Add(food);
        }
    }
}