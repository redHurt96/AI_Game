using RH_Modules.Utilities.Extensions;
using UnityEngine;

namespace _Project.Game.Domain
{
    public class FoodSpawner
    {
        private readonly FoodsRepository _foodsRepository;
        private float _progress;
        private readonly float _speed = 1f;

        public FoodSpawner(FoodsRepository foodsRepository)
        {
            _foodsRepository = foodsRepository;
        }

        public void Accumulate()
        {
            _progress = Mathf.Min(_progress + _speed * Time.deltaTime, 1f);

            if (_progress.ApproximatelyEqual(1f))
            {
                _foodsRepository.Add(new()
                {
                    FoodEnergy = 1f,
                    Position = new(Random.Range(-10, 10), 0f, Random.Range(-10, 10)),
                });
                _progress = 0f;
            }
        }

        public FoodSpawner Copy(FoodsRepository foodsRepository) =>
            new(foodsRepository)
            {
                _progress = _progress,
            };
    }
}