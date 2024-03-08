using System;
using _Project.Game.Extensions;
using UnityEngine;

namespace _Project.Game.Domain
{
    public class Food
    {
        public Vector3 Position;

        public event Action Destroyed;

        public Food(Vector3 position) => 
            Position = position;

        public Food Copy() => 
            new Food(Position);

        public override string ToString() =>
            this.GetFieldsDescription();

        public void Destroy() => 
            Destroyed?.Invoke();
    }
}