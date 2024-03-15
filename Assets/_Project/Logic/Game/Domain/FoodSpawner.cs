using System;
using _Project.Presentation;
using UniRx;
using Zenject;
using static System.TimeSpan;
using static UniRx.Observable;
using static UnityEngine.Object;
using static UnityEngine.Resources;
using Random = UnityEngine.Random;

namespace _Project.Game.Domain
{
    public class FoodSpawner : IInitializable, IDisposable
    {
        private readonly FoodsRepository _foodsRepository;
        private readonly CompositeDisposable _disposable;
        private readonly float _spawnDelay = 1f;

        public FoodSpawner(FoodsRepository foodsRepository)
        {
            _foodsRepository = foodsRepository;
            _disposable = new();
        }

        public void Initialize() =>
            Interval(FromSeconds(_spawnDelay))
                .Subscribe(x => CreateFood())
                .AddTo(_disposable);

        public void Dispose() => 
            _disposable.Dispose();

        private void CreateFood()
        {
            Food food = new(new(Random.Range(-10, 10), 0f, Random.Range(-10, 10)));
            Instantiate(Load<FoodView>("Food")).Setup(food);
            _foodsRepository.Add(food);
        }
    }
}