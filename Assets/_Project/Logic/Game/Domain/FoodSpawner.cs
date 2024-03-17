using System;
using UniRx;
using Zenject;
using static System.TimeSpan;
using static UniRx.Observable;

namespace _Project.Game.Domain
{
    public class FoodSpawner : IInitializable, IDisposable
    {
        private readonly FoodFactory _factory;
        private readonly CompositeDisposable _disposable;
        private readonly float _spawnDelay = 1f;

        public FoodSpawner(FoodFactory factory)
        {
            _factory = factory;
            _disposable = new();
        }

        public void Initialize() =>
            Interval(FromSeconds(_spawnDelay))
                .Subscribe(x => _factory.Create())
                .AddTo(_disposable);

        public void Dispose() => 
            _disposable.Dispose();

    }
}