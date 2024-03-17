using UnityEngine;
using Zenject;

namespace _Project.Game.Domain
{
    public class ManualFoodSpawner : ITickable
    {
        private readonly FoodFactory _foodFactory;

        public ManualFoodSpawner(FoodFactory foodFactory) => 
            _foodFactory = foodFactory;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.F))
                _foodFactory.Create();
        }
    }
}