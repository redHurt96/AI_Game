using _Project.Presentation;
using RH_Modules.Utilities.Extensions;
using UnityEngine;
using Zenject;
using static UnityEngine.Random;
using static UnityEngine.Time;

namespace _Project.Game.Domain
{
    public class FoodSpawner : ITickable
    {
        private readonly FoodsRepository _foodsRepository;
        private float _progress;
        private readonly float _speed = 1f;

        public FoodSpawner(FoodsRepository foodsRepository) => 
            _foodsRepository = foodsRepository;

        public void Tick()
        {
            _progress = Mathf.Min(_progress + _speed * deltaTime, 1f);

            if (_progress.ApproximatelyEqual(1f))
            {
                CreateFood();
                _progress = 0f;
            }
        }

        private void CreateFood()
        {
            Food food = new(new(Range(-10, 10), 0f, Range(-10, 10)));
            Object.Instantiate(Resources.Load<FoodView>("Food")).Setup(food);
            _foodsRepository.Add(food);
        }
    }
}