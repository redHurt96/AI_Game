using _Project.AI.Core;
using _Project.Game.Extensions;
using UniRx;

namespace _Project.Game.Domain
{
    public class Character : IActorContext
    {
        public bool HasTargetFood => TargetFood != null;
        public bool CloseEnoughToFood => HasTargetFood && MoveComponent.DistanceTo(TargetFood.Position) < Config.MoveStoppingDistance + .1f;
        public bool IsEat { get; set; }
        public bool IsAwake { get; set; } = true;

        public Food TargetFood;
        
        public readonly FoodsRepository WorldFood;
        public readonly IMoveComponent MoveComponent;
        public readonly ReactiveProperty<float> FoodEnergy;
        public readonly ReactiveProperty<float> Energy;
        public readonly CharacterConfig Config;

        public Character(
            float foodEnergy, 
            float energy, 
            FoodsRepository worldFood, 
            IMoveComponent moveComponent,
            CharacterConfig config)
        {
            WorldFood = worldFood;
            MoveComponent = moveComponent;
            FoodEnergy = new(foodEnergy);
            Energy = new(energy);
            Config = config;
        }

        private Character(Character origin)
        {
            WorldFood = origin.WorldFood.Copy();
            FoodEnergy = new(origin.FoodEnergy.Value);
            Energy = new(origin.Energy.Value);
            TargetFood = origin.TargetFood?.Copy();
            MoveComponent = new MockMoveComponent(origin.MoveComponent);
            Config = origin.Config;
        }

        public IActorContext Copy() =>
            new Character(this);

        public override string ToString() => 
            this.GetFieldsDescription();
    }
}
