using _Project.AI.Core;
using UnityEngine;

namespace _Project.Game.Domain
{
    public class NpcContext : IActorContext
    {
        public bool HasTargetFood => TargetFood.IsExist;
        
        public bool IsAwake;
        public float FoodEnergy;
        public float Energy;
        public float EatSpeed;
        public float SleepSpeed;
        public Vector3 Position;

        public Food TargetFood;

        private NpcContext(NpcContext origin)
        {
            IsAwake = origin.IsAwake;
            FoodEnergy = origin.FoodEnergy;
            Energy = origin.Energy;
            Position = origin.Position;
            EatSpeed = origin.EatSpeed;
            TargetFood = origin.TargetFood;
        }

        public IActorContext Copy() =>
            new NpcContext(this);
    }
}
