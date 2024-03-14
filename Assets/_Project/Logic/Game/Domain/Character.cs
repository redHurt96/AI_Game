using _Project.AI.Core;
using _Project.Game.Extensions;
using UniRx;

namespace _Project.Game.Domain
{
    public class Character : IActorContext
    {
        public bool HasTargetFood => TargetFood != null;
        public bool CloseEnoughToFood => HasTargetFood && MoveComponent.DistanceTo(TargetFood.Position) < _moveStoppingDistance + .1f;
        public bool IsEat { get; set; }
        public bool IsAwake { get; set; } = true;

        public Food TargetFood;
        
        public readonly FoodsRepository WorldFood;
        public readonly IMoveComponent MoveComponent;
        public readonly ReactiveProperty<float> FoodEnergy;
        public readonly ReactiveProperty<float> Energy;

        public readonly float EatSpeed = .5f;
        public readonly float SleepSpeed = .5f;
        public readonly float SpendEnergySpeed = .05f;
        public readonly float SpendFoodEnergySpeed = .05f;
        
        private readonly float _moveStoppingDistance = .5f;

        public Character(float foodEnergy, float energy, FoodsRepository worldFood, IMoveComponent moveComponent)
        {
            WorldFood = worldFood;
            MoveComponent = moveComponent;
            FoodEnergy = new(foodEnergy);
            Energy = new(energy);
        }

        private Character(Character origin)
        {
            WorldFood = origin.WorldFood.Copy();
            FoodEnergy = new(origin.FoodEnergy.Value);
            Energy = new(origin.Energy.Value);
            TargetFood = origin.TargetFood?.Copy();
            MoveComponent = new MockMoveComponent(origin.MoveComponent);
        }

        public IActorContext Copy() =>
            new Character(this);

        public override string ToString() => 
            this.GetFieldsDescription();
    }
}
