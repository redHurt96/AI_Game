using _Project.AI.Core;
using _Project.Game.Extensions;
using UniRx;
using UnityEngine;
using static UnityEngine.Vector3;

namespace _Project.Game.Domain
{
    public class NpcContext : IActorContext
    {
        public bool HasTargetFood => TargetFood != null;
        public float DistanceToFood => Distance(Position.Value, TargetFood.Position);
        public bool CloseEnoughToFood => HasTargetFood && DistanceToFood < MoveStoppingDistance;

        public bool IsAwake;
        public bool IsEat;
        public readonly ReactiveProperty<float> FoodEnergy;
        public readonly ReactiveProperty<float> Energy;
        public readonly ReactiveProperty<Vector3> Position;

        public readonly float MoveStoppingDistance = .5f;
        public readonly float MoveSpeed = 1f;
        public readonly float EatSpeed = .5f;
        public readonly float SleepSpeed = .5f;
        public readonly float SpendEnergySpeed = .1f;
        public readonly float SpendFoodEnergySpeed = .1f;

        public Food TargetFood;

        public NpcContext(bool isAwake, bool isEat, float foodEnergy, float energy, Vector3 position)
        {
            IsAwake = isAwake;
            IsEat = isEat;
            FoodEnergy = new(foodEnergy);
            Energy = new(energy);
            Position = new(position);
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
