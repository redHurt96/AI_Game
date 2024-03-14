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
        public bool CloseEnoughToFood => HasTargetFood && DistanceToFood < MoveStoppingDistance + .1f;

        public bool IsEat { get; set; }
        public bool IsAwake { get; set; } = true;
        public float ChillTimer { get; set; }

        public readonly FoodsRepository WorldFood;
        public readonly ReactiveProperty<float> FoodEnergy;
        public readonly ReactiveProperty<float> Energy;
        public readonly ReactiveProperty<Vector3> Position;

        public readonly float MoveStoppingDistance = .5f;
        public readonly float MoveSpeed = 5f;
        public readonly float EatSpeed = .5f;
        public readonly float SleepSpeed = .5f;
        public readonly float SpendEnergySpeed = .05f;
        public readonly float SpendFoodEnergySpeed = .05f;

        public Food TargetFood;

        public NpcContext(float foodEnergy, float energy, Vector3 position, FoodsRepository worldFood)
        {
            WorldFood = worldFood;
            FoodEnergy = new(foodEnergy);
            Energy = new(energy);
            Position = new(position);
        }

        private NpcContext(NpcContext origin)
        {
            WorldFood = origin.WorldFood.Copy();
            FoodEnergy = new(origin.FoodEnergy.Value);
            Energy = new(origin.Energy.Value);
            Position = new(origin.Position.Value);
            TargetFood = origin.TargetFood?.Copy();
        }

        public IActorContext Copy() =>
            new NpcContext(this);

        public override string ToString() => 
            this.GetFieldsDescription();
    }
}
