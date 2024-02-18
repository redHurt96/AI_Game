using _Project.AI.Core;
using _Project.Game.Extensions;
using UnityEngine;

namespace _Project.Game.Domain
{
    public class NpcContext : IActorContext
    {
        public bool HasTargetFood => TargetFood.IsExist;

        public bool IsAwake;
        public bool IsEat;
        public float FoodEnergy;
        public float Energy;
        public Vector3 Position;
        
        public readonly float EatSpeed = .5f;
        public readonly float SleepSpeed = .5f;
        public readonly float SpendEnergySpeed = .1f;
        public readonly float SpendFoodEnergySpeed = .1f;

        public Food TargetFood;

        public NpcContext(bool isAwake, bool isEat, float foodEnergy, float energy, Vector3 position)
        {
            IsAwake = isAwake;
            IsEat = isEat;
            FoodEnergy = foodEnergy;
            Energy = energy;
            Position = position;
        }

        private NpcContext(NpcContext origin)
        {
            IsEat = origin.IsEat;
            IsAwake = origin.IsAwake;
            FoodEnergy = origin.FoodEnergy;
            Energy = origin.Energy;
            Position = origin.Position;
            TargetFood = origin.TargetFood;
        }

        public IActorContext Copy() =>
            new NpcContext(this);

        public override string ToString() => 
            this.GetFieldsDescription();
    }
}
