using _Project.Game.Extensions;
using UnityEngine;

namespace _Project.Game.Domain
{
    public struct Food
    {
        public bool IsExist => FoodEnergy > 0;
        public Vector3 Position;

        public float FoodEnergy;
        
        public Food(Food fromOrigin)
        {
            Position = fromOrigin.Position;
            FoodEnergy = fromOrigin.FoodEnergy;
        }

        public override string ToString() =>
            this.GetFieldsDescription();
    }
}