using System;
using _Project.Game.Extensions;
using UniRx;
using UnityEngine;

namespace _Project.Game.Domain
{
    public class Food
    {
        public Vector3 Position;

        public event Action Destroyed;
        public readonly ReactiveProperty<float> FoodEnergy;

        public Food(float energy, Vector3 position)
        {
            Position = position;
            FoodEnergy = new(energy);
        }
        
        public Food(Food fromOrigin) : this(fromOrigin.FoodEnergy.Value, fromOrigin.Position)
        {
        }

        public override string ToString() =>
            this.GetFieldsDescription();

        public void Destroy() => 
            Destroyed?.Invoke();
    }
}