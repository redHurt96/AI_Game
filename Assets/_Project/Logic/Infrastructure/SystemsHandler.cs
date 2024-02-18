using System;
using System.Collections.Generic;
using UniRx;
using Zenject;

namespace _Project.Infrastructure
{
    public class SystemsHandler : ITickable, IDisposable
    {
        private readonly IInstantiator _instantiator;
        private readonly List<ITickable> _toUpdate = new();
        private readonly CompositeDisposable _toDispose = new();

        public SystemsHandler(IInstantiator instantiator) => 
            _instantiator = instantiator;

        public void Tick() => 
            _toUpdate.ForEach(x => x.Tick());

        public void Dispose() => 
            _toDispose.Dispose();

        public void Instantiate<T>()
        {
            T instance = _instantiator.Instantiate<T>();
            
            if (instance is IInitializable initializable)
                initializable.Initialize();
            
            if (instance is ITickable tickable)
                _toUpdate.Add(tickable);
            
            if (instance is IDisposable disposable)
                _toDispose.Add(disposable);
        }
    }
}